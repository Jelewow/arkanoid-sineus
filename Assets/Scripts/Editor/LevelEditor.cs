using System;
using Block.Managers;
using Block.MonoBehaviours;
using Block.ScriptableObjects;
using Block.Services;
using Level.ScriptableObjects;
using Level.Services;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Editor
{
    public class LevelEditor : EditorWindow
    {
        private Transform _parent;
        private BlockDatabase _blockDatabase;
        private int _index;
        private bool _isEdit;
        private LevelData _levelData;
        private BlockView _blockPrefab;
        private SceneEditor _sceneEditor;
        private BlockDestroyManager _blockDestroyManager;
        
        [MenuItem("Arkanoid/Level Editor")]
        public static void Init()
        {
            var levelEditor = GetWindow<LevelEditor>("Level Editor");
            levelEditor.Show();
        }

        private void OnGUI()
        {
            EditorGUILayout.Space(10);
            
            GUILayout.Label("Prefab");
            _blockPrefab = (BlockView)EditorGUILayout.ObjectField(_blockPrefab, typeof(BlockView), true);
            
            GUILayout.Label("Block Manager");
            _blockDestroyManager = (BlockDestroyManager)EditorGUILayout.ObjectField(_blockDestroyManager, typeof(BlockDestroyManager), true);
            
            GUILayout.Label("Parent");
            _parent = (Transform)EditorGUILayout.ObjectField(_parent, typeof(Transform), true);
            EditorGUILayout.Space(30);

            if (!_blockDatabase)
            {
                if (GUILayout.Button("Load database"))
                {
                    _blockDatabase =
                        (BlockDatabase)AssetDatabase.LoadAssetAtPath("Assets/Settings/Block/BlockDatabase.asset",
                            typeof(BlockDatabase));

                    _sceneEditor = CreateInstance<SceneEditor>();
                    _sceneEditor.SetLevelEditor(this, _parent, _blockPrefab, _blockDestroyManager);
                }
            }
            else
            {
                GUILayout.BeginHorizontal();
                GUILayout.FlexibleSpace();
                GUILayout.Label("Block Prefab", EditorStyles.boldLabel);
                GUILayout.FlexibleSpace();
                GUILayout.EndHorizontal();

                GUILayout.Space(5);
                GUILayout.BeginHorizontal();
                GUILayout.FlexibleSpace();
                if (GUILayout.Button("<-", GUILayout.Width(50), GUILayout.Height(50)))
                {
                    _index--;
                    if (_index < 0)
                    {
                        _index = _blockDatabase.Blocks.Count - 1;
                    }
                }

                GUILayout.Label(SpriteToTexture2D(_blockDatabase.Blocks[_index].Sprites[0]));

                if (GUILayout.Button("->", GUILayout.Width(50), GUILayout.Height(50)))
                {
                    _index++;
                    if (_index > _blockDatabase.Blocks.Count)
                    {
                        _index = 0;
                    }
                }

                GUILayout.FlexibleSpace();
                GUILayout.EndHorizontal();
                
                GUILayout.Space(30);
                GUI.color = _isEdit ? Color.red : Color.white;
                if (GUILayout.Button("Create blocks"))
                {
                    _isEdit = !_isEdit;

                    if (!_sceneEditor)
                    {
                        _sceneEditor = CreateInstance<SceneEditor>();
                        
                    }
                    
                    _sceneEditor.SetLevelEditor(this, _parent, _blockPrefab, _blockDestroyManager);
                    
                    if (_isEdit)
                    {
                        SceneView.duringSceneGui += _sceneEditor.OnSceneGUI;
                    }
                    else
                    {
                        SceneView.duringSceneGui -= _sceneEditor.OnSceneGUI;
                    }
                }
                GUI.color = Color.white;
                GUILayout.Space(30);
                
                _levelData = EditorGUILayout.ObjectField(_levelData, typeof(LevelData), false) as LevelData;
                
                GUILayout.BeginHorizontal();
                if (GUILayout.Button("Save level"))
                {
                    var saveService = new SaveLevelService();
                    _levelData.Blocks = saveService.GetBlocks();
                    EditorUtility.SetDirty(_levelData);
                    Debug.Log("Saved");
                }

                if (GUILayout.Button("Load level"))
                {
                    var blocks = Object.FindObjectsOfType<BlockView>();
                    foreach (var blockView in blocks)
                    {
                        DestroyImmediate(blockView.gameObject);
                    }

                    var spawner = new BlockSpawnService();
                    var newBlocks = spawner.Spawn(_levelData, _parent, _blockPrefab, _blockDestroyManager);
                    foreach (var block in newBlocks)
                    {
                        EditorUtility.SetDirty(block);
                    }
                }
                
                GUILayout.EndHorizontal();
            }
        }

        public BlockData GetBlock()
        {
            return _blockDatabase.Blocks[_index];
        }
        
        private Texture2D SpriteToTexture2D(Sprite sprite)
        {
            var croppedTexture = new Texture2D((int)sprite.rect.width, (int)sprite.rect.height);
            var pixels = sprite.texture.GetPixels((int)sprite.textureRect.x,
                (int)sprite.textureRect.y,
                (int)sprite.textureRect.width,
                (int)sprite.textureRect.height);
            croppedTexture.SetPixels(pixels);
            croppedTexture.Apply();

            return croppedTexture;
        }
    }
}
using Block.Managers;
using Block.MonoBehaviours;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    public class SceneEditor : EditorWindow
    {
        private readonly EditorGrid _editorGrid = new EditorGrid();

        private BlockView _prefab;
        private LevelEditor _levelEditor;
        private Transform _parent;
        private BlockDestroyManager _blockDestroyManager;

        public void SetLevelEditor(LevelEditor levelEditor, Transform parent, BlockView prefab, BlockDestroyManager blockDestroyManager)
        {
            _levelEditor = levelEditor;
            _parent = parent;
            _prefab = prefab;
            _blockDestroyManager = blockDestroyManager;
        }

        public void OnSceneGUI(SceneView sceneView)
        {
            var current = Event.current;
            if (current.type == EventType.MouseDown)
            {
                float pixelsPerPoint = EditorGUIUtility.pixelsPerPoint;
                Vector2 mouse = current.mousePosition;
                mouse.x *= pixelsPerPoint;
                mouse.y = sceneView.camera.pixelHeight - mouse.y * pixelsPerPoint;
                var point = (Vector2) sceneView.camera.ScreenToWorldPoint(mouse);
                var vector = _editorGrid.CheckPosition(point);
                
                if (IsEmpty(vector))
                {
                    var block = PrefabUtility.InstantiatePrefab(_prefab, _parent) as BlockView;
                    block.transform.position = vector;
                    block.Init(_levelEditor.GetBlock(), _blockDestroyManager);
                }
            }

            if (current.type == EventType.Layout)
            {
                HandleUtility.AddDefaultControl(GUIUtility.GetControlID(GetHashCode(), FocusType.Passive));
            }
        }

        private bool IsEmpty(Vector2 position)
        {
            var collider = Physics2D.OverlapCircle(position, 0.01f);
            return !collider;
        }
    }
}
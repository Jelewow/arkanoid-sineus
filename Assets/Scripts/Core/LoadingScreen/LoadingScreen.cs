using DG.Tweening;
using TMPro;
using UnityEngine;

namespace Jelewow.Arkanoid.SceneManagement
{
    public class LoadingScreen : MonoBehaviour, ICoroutineRunner
    {
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private TextMeshProUGUI _loadingInfo;
        
        [SerializeField] private float _durationToHide;
        [SerializeField] private float _durationToShow;

        private void Awake()
        {
            Init();
            
            DontDestroyOnLoad(this);
        }

        private void Reload()
        {
            _loadingInfo.text = "Loading 0%";
        }
        
        private void Init()
        {
            gameObject.SetActive(false);
            _canvasGroup.alpha = 0;
        }
        
        public void Show()
        {
            Reload();
            gameObject.SetActive(true);
            _canvasGroup.DOFade(1, _durationToShow);
        }

        public void Hide()
        {
            _canvasGroup.DOFade(0, _durationToHide).OnComplete(() => gameObject.SetActive(false));
            Reload();
        }

        public void UpdateProgress(float loadingProgress)
        {
            _loadingInfo.text = "Loading " +  loadingProgress * 100f + "%";
        }
    }
}
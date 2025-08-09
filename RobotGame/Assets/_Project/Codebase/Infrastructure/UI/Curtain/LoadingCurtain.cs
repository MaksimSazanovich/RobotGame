using System;
using PrimeTween;
using UnityEngine;

namespace Infrastructure.UI
{
    public class LoadingCurtain : MonoBehaviour
    {
        private float showDuration;
        private float hideDuration;
        
        private CanvasGroup canvasGroup;

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }

        public void Init(float showDuration, float hideDuration)
        {
            this.showDuration = showDuration;
            this.hideDuration = hideDuration;
            
            canvasGroup = GetComponent<CanvasGroup>();
            canvasGroup.alpha = 0;
        }

        public void Show()
        {
            Tween.Alpha(canvasGroup, 1, showDuration);
        }

        public void Hide(Action onHidden = null)
        {
            Tween.Alpha(canvasGroup, 0, hideDuration).OnComplete(
                () => onHidden?.Invoke());
        }
    }
}
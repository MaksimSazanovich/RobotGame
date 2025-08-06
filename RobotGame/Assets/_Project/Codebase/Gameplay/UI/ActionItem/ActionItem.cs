using System;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Unity_one_love.RobotGame
{
    public class ActionItem : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
    {
        public static Action<bool, ExecutionSlot> OnBeginDragged;
        public static event Action<float> OnDragged;
        public static Action<bool> OnEndDragged;

        [SerializeField] private RectTransform rectTransform;
        [SerializeField] private Canvas canvas;
        [SerializeField] private RectTransform background;
        [SerializeField] private VerticalLayoutGroup actionPool;
        [SerializeField] private VerticalLayoutGroup executionPanel;

        private int index;
        private bool isReplaced;

        private void Start()
        {
            index = rectTransform.GetSiblingIndex();
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            actionPool.enabled = false;
            executionPanel.enabled = false;
            //rectTransform.SetParent(executionPanel.transform);
            rectTransform.SetAsLastSibling();

            transform.parent.TryGetComponent(out ExecutionSlot executionSlot);
            OnBeginDragged?.Invoke(isReplaced, executionSlot);
        }

        public void OnDrag(PointerEventData eventData)
        {
            rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor / background.localScale.x;

            if (rectTransform.position.x > 7)
            {
                rectTransform.SetParent(executionPanel.transform);
                rectTransform.SetAsLastSibling();

                OnDragged?.Invoke(rectTransform.position.y);
                //Debug.Log(rectTransform.position.y);
            }
            else
            {
                rectTransform.SetParent(actionPool.transform);
                rectTransform.SetAsLastSibling();
            }

            rectTransform.localScale = Vector3.one;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            actionPool.enabled = true;
            executionPanel.enabled = true;

            if (rectTransform.position.x > 7) //TODO:Убрать магическое число
            {
                rectTransform.SetParent(executionPanel.GetComponentsInChildren<ExecutionSlot>()
                    .First(s => s.IsEmpty).transform);
                rectTransform.SetSiblingIndex(1);
                isReplaced = true;
                //rectTransform.SetAsFirstSibling();
            }
            else
            {
                rectTransform.SetSiblingIndex(index);
                isReplaced = false;
            }

            rectTransform.localPosition = Vector3.zero;
            OnEndDragged?.Invoke(isReplaced);
        }
    }
}
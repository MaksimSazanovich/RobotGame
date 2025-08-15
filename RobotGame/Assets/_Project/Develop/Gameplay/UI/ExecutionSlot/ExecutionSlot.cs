using UnityEngine;
using Zenject;

namespace Unity_one_love.RobotGame
{
    public class ExecutionSlot : MonoBehaviour
    {
        [field: SerializeField] public RectTransform RectTransform { get; private set; }
        public bool IsEmpty = true;
        private ExecutionSlotsPanel executionSlotsPanel;
        
        [Inject]
        private void Constructor(ExecutionSlotsPanel executionSlotsPanel)
        {
            this.executionSlotsPanel = executionSlotsPanel;
        }

        private void Start()
        {
            IsEmpty = HasChildren();
        }

        private void OnEnable()
        {
            ActionItem.OnDragged += OnActionSlotDragged;
            ActionItem.OnEndDragged += OnActionSlotEndDragged;
        }

        private void OnDisable()
        {
            ActionItem.OnDragged -= OnActionSlotDragged;
        }

        private void OnActionSlotEndDragged(bool isReplaced)
        {
            if (!isReplaced)
                return;

            IsEmpty = HasChildren();
        }

        private void OnActionSlotDragged(float y)
        {
            if (!IsEmpty)
                return;

            transform.position = new Vector3(transform.position.x, y, transform.position.z);
            int index = executionSlotsPanel.CurrentPositionList.FindIndex(y => RectTransform.position.y <= y);
            Debug.Log(index);
            if (index == -1)
                RectTransform.SetAsFirstSibling();
            else
                RectTransform.SetSiblingIndex(executionSlotsPanel.CurrentPositionList.Count - index);
        }

        private bool HasChildren()
        {
            return transform.childCount == 0;
        }
    }
}
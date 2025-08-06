using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Unity_one_love.RobotGame
{
    public class ExecutionSlotsPanel : MonoBehaviour
    {
        public float[] CurrentPositionList { get; private set; }

        private float[][] PositionsLists =
        {
            new[] { -0.76f },
            new[] { -1.71f, 0.19f },
            new[] { -2.66f, -0.76f, 1.14f },
            new[] { -3.61f, -1.71f, 0.19f, 2.09f },
            new[] { -4.56f, -2.66f, -0.76f, 1.14f, 3.04f }
        };

        private List<ExecutionSlot> executionSlots = new();

        private ExecutionSlot lastSlot;

        private void Start()
        {
            CurrentPositionList = PositionsLists[2];
            executionSlots = GetComponentsInChildren<ExecutionSlot>().ToList();
        }

        private void OnEnable()
        {
            ActionItem.OnBeginDragged += HandleBeginDragged;
            ActionItem.OnDragged += HandleDragged;
            ActionItem.OnEndDragged += HandleEndDragged;
        }

        private void OnDisable()
        {
            ActionItem.OnBeginDragged -= HandleBeginDragged;
            ActionItem.OnEndDragged -= HandleEndDragged;
        }

        private void Update()
        {
//            Debug.Log("last slot: " + lastSlot.RectTransform.position.y);
            Debug.Log("CurrentSlotList.Length: " + CurrentPositionList.Length);
        }

        private void HandleBeginDragged(bool itemReplaced, ExecutionSlot slot)
        {
            if (slot)
                lastSlot = slot;

            if (itemReplaced)
            {
                ReduceSlot();
            }
            else
            {
                AddSlot();
            }
            
            executionSlots = GetComponentsInChildren<ExecutionSlot>().ToList();
        }

        private void HandleDragged(float y)
        {
            Debug.Log("executionSlots.Count: " + executionSlots.Count);
            for (int i = 0; i < executionSlots.Count; i++)
            {
                Vector3 transformPosition = executionSlots[i].transform.position;
                executionSlots[i].RectTransform.position = new Vector3(transformPosition.x,
                    CurrentPositionList[CurrentPositionList.Length - 1 - i], transformPosition.z);
            }
        }

        private void HandleEndDragged(bool itemMoved)
        {
            if (!itemMoved)
            {
                lastSlot.gameObject.SetActive(false);
            }
            executionSlots = GetComponentsInChildren<ExecutionSlot>().ToList();

        }

        private void ReduceSlot()
        {
            lastSlot.IsEmpty = true;
            lastSlot.GetComponentInChildren<RectTransform>().SetParent(transform);
            lastSlot.GetComponentInChildren<RectTransform>().SetAsLastSibling();
            CurrentPositionList = PositionsLists[transform.GetComponentsInChildren<ExecutionSlot>().Length - 1];
        }

        private void AddSlot()
        {
            lastSlot = GetComponentsInChildren<ExecutionSlot>(true).First(s => s.gameObject.activeInHierarchy == false);
            lastSlot.RectTransform.SetAsLastSibling();
            lastSlot.gameObject.SetActive(true);
            Debug.Log(transform.GetComponentsInChildren<ExecutionSlot>().Length - 1);
            CurrentPositionList = PositionsLists[transform.GetComponentsInChildren<ExecutionSlot>().Length - 1];
            
        }
    }
}
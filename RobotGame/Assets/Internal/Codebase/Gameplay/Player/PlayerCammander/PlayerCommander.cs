using System.Collections;
using UnityEngine;

namespace Unity_one_love.RobotGame
{
    public abstract class PlayerCommander : MonoBehaviour
    {
        protected bool isFinished = false;

        protected float defaultWaitTime = 1;
        public virtual bool IsFinished() => isFinished;
        
        protected IEnumerator WaitCoroutine()
        {
            yield return new WaitForSeconds(defaultWaitTime);
            isFinished = true;
        }
    }
}
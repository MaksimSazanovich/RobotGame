using System.Collections;
using UnityEngine;
using Zenject;

namespace Unity_one_love.RobotGame
{
    public abstract class PlayerCommander : MonoBehaviour
    {
        protected bool isFinished = false;

        protected float defaultWaitTime = 1;
        protected Player player;

        [Inject]
        protected virtual void Constructor(Player player)
        {
            this.player = player;
        }
        
        protected virtual void Start()
        {
            player.CheckCurrentDirection();
        }

        public virtual bool IsFinished() => isFinished;
        
        protected IEnumerator WaitCoroutine()
        {
            yield return new WaitForSeconds(defaultWaitTime);
            isFinished = true;
        }
    }
}
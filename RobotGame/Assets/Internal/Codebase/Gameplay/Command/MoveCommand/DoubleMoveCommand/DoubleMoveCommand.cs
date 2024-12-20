using System.Collections;
using UnityEngine;

namespace Unity_one_love.RobotGame
{
    public class DoubleMoveCommand : MoveCommand
    {
        private float waitingTime;

        public DoubleMoveCommand(PlayerMover playerMover)
        {
            this.playerMover = playerMover;
        }
        
        public override void Execute()
        {
            playerMover.StartCoroutine(DoubleMoveCoroutine());
        }

        private IEnumerator DoubleMoveCoroutine()
        {
            var dir = GetVectorDirection();
            playerMover.Move(dir.x, dir.y);
            waitingTime = 0.5f;
            yield return new WaitForSeconds(waitingTime);
            playerMover.Move(dir.x, dir.y);
        }

        public override bool CanBeExecuted() => true;
    }
}
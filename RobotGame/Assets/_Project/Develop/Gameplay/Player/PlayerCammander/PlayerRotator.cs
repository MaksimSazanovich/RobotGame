using UnityEngine;

namespace Unity_one_love.RobotGame
{
    public class PlayerRotator : PlayerCommander
    {
        public void Rotate(RotationDirection direction)
        {
            isFinished = false;

            player.transform.Rotate(Vector3.forward, 90f * (int)direction);

            player.CheckCurrentDirection();
            StartCoroutine(WaitCoroutine());
        }
    }
}
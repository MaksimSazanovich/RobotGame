using UnityEngine;

namespace Unity_one_love.RobotGame
{
    public class PlayerMover : PlayerCommander
    {
        [SerializeField] private float stepLength;
        
        public MoveDirection GetCurrentDirection()
        {
            return player.CurrentDirection;
        }

        public void Move(int xDelta, int yDelta)
        {
            isFinished = false;
            player.transform.position += new Vector3(transform.position.x + xDelta*stepLength,
                transform.position.y + yDelta*stepLength, transform.position.z);
            StartCoroutine(WaitCoroutine());
        }
    }
}
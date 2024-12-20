using UnityEngine;
using Zenject;

namespace Unity_one_love.RobotGame
{
    public class PlayerMover : PlayerCommander
    {
        private Player player;
        private Transform transform;
        
        [Inject]
        private void Constructor(Player player)
        {
            this.player = player;
        }

        private void Start()
        {
            transform = GetComponent<Transform>();
        }

        public MoveDirection GetCurrentDirection()
        {
            return player.CurrentDirection;
        }

        public void Move(int xDelta, int yDelta)
        {
            isFinished = false;
            player.transform.position += new Vector3(transform.position.x + xDelta, transform.position.y + yDelta, transform.position.z);
            StartCoroutine(WaitCoroutine());
        }
    }
}
using UnityEngine;

namespace Unity_one_love.RobotGame
{
    public abstract class MoveCommand : Command
    {
        protected PlayerMover playerMover;
        protected Vector2Int direction;

        public override PlayerCommander GetPlayerCommander() => playerMover;

        protected Vector2Int GetVectorDirection()
        {
            Vector2Int vector = new Vector2Int();
            switch (playerMover.GetCurrentDirection())
            {
                case MoveDirection.Up:
                    vector = Vector2Int.up;
                    break;
                case MoveDirection.Down:
                    vector = Vector2Int.down;
                    break;
                case MoveDirection.Left:
                    vector = Vector2Int.left;
                    break;
                case MoveDirection.Right:
                    vector = Vector2Int.right;
                    break;
            }

            return vector;
        }
    }
}
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
                    vector = new Vector2Int(0, 1);
                    break;
                case MoveDirection.Down:
                    vector = new Vector2Int(0, -1);
                    break;
                case MoveDirection.Left:
                    vector = new Vector2Int(-1, 0);
                    break;
                case MoveDirection.Right:
                    vector = new Vector2Int(1, 0);
                    break;
            }
            return vector;
        }
    }
}
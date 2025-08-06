using UnityEngine;

namespace Unity_one_love.RobotGame
{
    public class Player : MonoBehaviour
    {
        public MoveDirection CurrentDirection { get; private set; } = MoveDirection.Down;

        public void CheckCurrentDirection()
        {
            switch (transform.rotation.eulerAngles.z)
            {
                case 0: CurrentDirection = MoveDirection.Down; break;
                case 270: CurrentDirection = MoveDirection.Left; break;
                case 90: CurrentDirection = MoveDirection.Right; break;
                case 180: CurrentDirection = MoveDirection.Up; break;
            }
        }
    }
}
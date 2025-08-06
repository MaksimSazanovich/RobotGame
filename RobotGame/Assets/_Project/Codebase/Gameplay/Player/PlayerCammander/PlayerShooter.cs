using UnityEngine;

namespace Unity_one_love.RobotGame
{
    public class PlayerShooter : PlayerCommander
    {
        public void Shoot()
        {
            Debug.Log("Shoot");
            StartCoroutine(WaitCoroutine());
        }
    }
}
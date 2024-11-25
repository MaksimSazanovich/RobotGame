using System;
using System.Collections;
using UnityEngine;
using Zenject;

namespace Unity_one_love.RobotGame
{
    public class PlayerRotator : PlayerCommander
    {
        private Player player;

        [Inject]
        private void Constructor(Player player)
        {
            this.player = player;
        }

        public void Rotate(RotationDirection direction)
        {
            isFinished = false;

            player.transform.Rotate(Vector3.forward, 90f * (int)direction);

            player.CheckCurrentDirection();
            StartCoroutine(WaitCoroutine());
        }
    }
}
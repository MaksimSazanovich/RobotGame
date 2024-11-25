using System.Collections;
using UnityEngine;

namespace Unity_one_love.RobotGame
{
    public class PlayerWaiter : PlayerCommander
    {
        private float waitTime = 3;
        
        public void Wait()
        {
            isFinished = false;
            StartCoroutine(WaitCoroutine());
        }
    }
}
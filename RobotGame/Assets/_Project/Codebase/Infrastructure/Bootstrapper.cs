using System;
using UnityEngine;
using UnityEngine.PlayerLoop;
using Zenject;

namespace Unity_one_love.RobotGame
{
    public class Bootstrapper : MonoBehaviour
    {
        private GameStateMachine gameStateMachine;

        [Inject]
        private void Constructor(GameStateMachine gameStateMachine)
        {
            this.gameStateMachine = gameStateMachine;
        }

        private void Awake()
        {
            Init();
        }

        private void Init()
        {
            if (Exist())
            {
                Destroy(gameObject);
            }

            EnterBootstrapState();
        }

        private void EnterBootstrapState()
        {
            gameStateMachine.Enter<BootstrapState>();
        }

        private bool Exist()
        {
            Bootstrapper bootstrapper = FindObjectOfType<Bootstrapper>();
            return bootstrapper is not null && bootstrapper != this;
        }
    }
}
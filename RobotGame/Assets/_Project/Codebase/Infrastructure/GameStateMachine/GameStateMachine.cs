using System;
using System.Collections.Generic;
using Zenject;

namespace Unity_one_love.RobotGame
{
    public class GameStateMachine
    {
        private Dictionary<Type, IExitableState> states;
        private IExitableState currentState;

        [Inject]
        public GameStateMachine(BootstrapState bootstrapState)
        {
            states = new Dictionary<Type, IExitableState>()
            {
                [typeof(BootstrapState)] = bootstrapState,
            };
        }

        public void Enter<TState>() where TState : IState
        {
            currentState?.Exit();
            currentState = states[typeof(TState)];
            (currentState as IState)?.Enter();
        }
    }
}
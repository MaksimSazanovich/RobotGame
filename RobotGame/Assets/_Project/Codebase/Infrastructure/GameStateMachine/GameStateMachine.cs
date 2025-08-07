using System;
using System.Collections.Generic;
using Zenject;

namespace Unity_one_love.RobotGame
{
    public class GameStateMachine
    {
        private Dictionary<Type, IState> states = new();
        private IState currentState;

        /*[Inject]
        public GameStateMachine(BootstrapState bootstrapState)
        {
            states = new Dictionary<Type, IState>()
            {
                [typeof(BootstrapState)] = bootstrapState,
            };
        }*/

        public void AddState(IState state)
        {
            states[state.GetType()] = state;
        }

        public void Enter<TState>() where TState : IState
        {
            currentState?.Exit();
            currentState = states[typeof(TState)];
            (currentState as IState)?.Enter();
        }
    }
}
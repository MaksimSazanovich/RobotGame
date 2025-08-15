using System;
using System.Collections.Generic;

namespace UnityOneLove.States
{
    public class GameStateMachine
    {
        public Dictionary<Type, IExitableState> States {get; private set;} = new();
        private IExitableState currentState;

        public void AddState(IExitableState state)
        {
            States[state.GetType()] = state;
        }

        public void Enter<TState>() where TState : class, IState
        {
            IState state = ChangeState<TState>();
            state.Enter();
        }

        public void Enter<TState, TPayload>(TPayload args) where TState : class, IPayloadState<TPayload>
        {
            TState state = ChangeState<TState>();
            state.Enter(args);
        }

        private TState ChangeState<TState>() where TState : class, IExitableState
        {
            if (currentState == States[typeof(TState)])
                return (TState)currentState;
            
            currentState?.Exit();
            TState state = States[typeof(TState)] as TState;
            currentState = state;
            return state;
        }
    }
}
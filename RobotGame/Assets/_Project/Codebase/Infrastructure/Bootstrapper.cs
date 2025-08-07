using UnityEngine;
using Zenject;

namespace Unity_one_love.RobotGame
{
    public class Bootstrapper : MonoBehaviour
    {
        private GameStateMachine gameStateMachine;
        
        private DIContainer projectContainer = new DIContainer();

        /*[Inject]
        private void Constructor(GameStateMachine gameStateMachine)
        {
            this.gameStateMachine = gameStateMachine;
        }*/

        private void Awake()
        {
            projectContainer.RegisterInterface<BootstrapState, IState>(_ =>
                new BootstrapState(gameStateMachine));
            
            Debug.Log(projectContainer.Resolve<IState>().ToString());
            projectContainer.RegisterSingleton(_ => new GameStateMachine());
            
            gameStateMachine = projectContainer.Resolve<GameStateMachine>();
            gameStateMachine.AddState(new BootstrapState(gameStateMachine));
            
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
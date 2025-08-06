using Zenject;

namespace Unity_one_love.RobotGame
{
    public class GameStateInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<BootstrapState>().AsSingle();
            Container.Bind<GameStateMachine>().AsSingle();
        }
    }
}
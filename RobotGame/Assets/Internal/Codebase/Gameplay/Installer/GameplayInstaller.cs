using Unity_one_love.RobotGame;
using UnityEngine;
using Zenject;

namespace Internal.Codebase.Gameplay.Installer
{
    public class GameplayInstaller : MonoInstaller
    {
        [SerializeField] private TurnManager turnManager;
        [SerializeField] private CommandFactory commandFactory;
        [SerializeField] private Player player;
        
        [SerializeField] private PlayerMover playerMover;
        [SerializeField] private PlayerWaiter playerWaiter;
        [SerializeField] private PlayerRotator playerRotator;
        [SerializeField] private PlayerShooter playerShooter;

        public override void InstallBindings()
        {
            Container.Bind<TurnManager>().FromInstance(turnManager).AsSingle();
            Container.Bind<CommandFactory>().FromInstance(commandFactory).AsSingle();
            Container.Bind<Player>().FromInstance(player).AsSingle();
            
            Container.Bind<PlayerMover>().FromInstance(playerMover).AsSingle();
            Container.Bind<PlayerWaiter>().FromInstance(playerWaiter).AsSingle();
            Container.Bind<PlayerRotator>().FromInstance(playerRotator).AsSingle();
            Container.Bind<PlayerShooter>().FromInstance(playerShooter).AsSingle();
        }
    }
}
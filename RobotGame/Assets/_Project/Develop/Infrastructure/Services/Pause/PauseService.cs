using UnityOneLove.Core;
using UnityOneLove.DI;
using ModestTree;

namespace UnityOneLove.Services.Pause
{
    public class PauseService : IPauseService
    {
        private readonly DIContainer projectContainer;
        private readonly PauseRepository repository;
        
        private readonly bool isPaused;

        public PauseService()
        {
            projectContainer = Game.ProjectContainer;

            repository = projectContainer.Resolve<PauseRepository>();
        }
        
        public void Pause()
        {
            if(repository.Pausables.IsEmpty())
                return;
            
            foreach (var pausable in repository.Pausables)
            {
                pausable.OnPause();
            }
        }

        public void Resume()
        {
            if(repository.Pausables.IsEmpty())
                return;
            
            foreach (var pausable in repository.Pausables)
            {
                pausable.OnResume();
            }
        }
    }
}
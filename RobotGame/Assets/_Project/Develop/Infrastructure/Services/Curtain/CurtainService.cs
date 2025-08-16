using UnityOneLove.Core;
using UnityOneLove.DI;
using UnityOneLove.Infrastructure.Factories;
using UnityOneLove.Infrastructure.UI;

namespace UnityOneLove.Services.Curtain
{
    public class CurtainService : ICurtainService
    {
        private readonly DIContainer projectContainer;
        
        private readonly LoadingCurtain curtain;

        public CurtainService()
        {
            projectContainer = Game.ProjectContainer;
            
            curtain = projectContainer.Resolve<IUIFactory>().CreateLoadingCurtain();
        }
        
        public void Show()
        {
            curtain.Show();
        }

        public void Hide()
        {
            curtain.Hide();
        }
    }
}
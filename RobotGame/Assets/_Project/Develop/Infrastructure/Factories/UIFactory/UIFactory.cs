using UnityOneLove.AssetMenegement;
using UnityOneLove.Core;
using UnityOneLove.DI;
using UnityOneLove.Infrastructure.UI;
using UnityEngine;

namespace UnityOneLove.Infrastructure.Factories
{
    public class UIFactory : IUIFactory
    {
        private readonly DIContainer projectContainer;
        private readonly IAssetProvider assetProvider;

        public UIFactory()
        {
            projectContainer = Game.ProjectContainer;
            assetProvider = projectContainer.Resolve<IAssetProvider>();
        }
        
        public LoadingCurtain CreateLoadingCurtain()
        {
            var config = assetProvider.LoadCurtainConfig();
            var curtain = Object.Instantiate(config.CurtainPrefab).GetComponent<LoadingCurtain>();
            
            curtain.Init(config.ShowDuration, config.HideDuration);
            
            return curtain;
        }
    }
}
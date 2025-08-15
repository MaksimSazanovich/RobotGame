using UnityOneLove.Infrastructure.UI;
using UnityEngine;

namespace UnityOneLove.AssetMenegement
{
    public class AssetProvider : IAssetProvider
    {
        public LoadingCurtainConfig LoadCurtainConfig()
        {
            return Resources.Load<LoadingCurtainConfig>(AssetPath.LOADING_CURTAIN_CONFIG);
        }
    }
}
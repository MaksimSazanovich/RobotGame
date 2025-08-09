using Infrastructure.UI;
using UnityEngine;

namespace AssetMenegement
{
    public class AssetProvider : IAssetProvider
    {
        public LoadingCurtainConfig LoadCurtainConfig()
        {
            return Resources.Load<LoadingCurtainConfig>(AssetPath.LOADING_CURTAIN_CONFIG);
        }
    }
}
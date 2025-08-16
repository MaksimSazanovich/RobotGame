using UnityEngine;

namespace UnityOneLove.Infrastructure.UI
{
    [CreateAssetMenu(fileName = "LoadingCurtainConfig", menuName = "StaticData/Infrastructure/LoadingCurtainConfig", order = 0)]
    public class LoadingCurtainConfig : ScriptableObject
    {
        [field: SerializeField] public LoadingCurtain CurtainPrefab { get; private set; }
        
        [field: Space(20)]
        [field: Header("Settings")]
        [field: SerializeField] public float ShowDuration { get; private set; }
        [field: SerializeField] public float HideDuration { get; private set; }
    }
}
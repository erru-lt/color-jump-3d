using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.StaticData.WindowStaticData
{
    [CreateAssetMenu(fileName = "WindowStaticData", menuName = "Static Data/Window")]
    public class WindowStaticData : ScriptableObject
    {
        public List<WindowConfig> WindowConfigs; 
    }
}

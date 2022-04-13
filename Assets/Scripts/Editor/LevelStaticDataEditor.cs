using UnityEngine;
using UnityEditor;
using Assets.Scripts.StaticData;
using Assets.Scripts.Logic.Platforms;
using System.Linq;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Editor
{
    [CustomEditor(typeof(LevelStaticData))]
    public class LevelStaticDataEditor : UnityEditor.Editor
    {
        private const string HeroInitialPointTag = "HeroInitialPoint";
        private const string InitialPlatformTag = "InitialPlatform";
        private const string LevelEndpointTag = "LevelEndpoint";

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            LevelStaticData levelStaticData = (LevelStaticData)target;

            if(GUILayout.Button("Collect"))
            {
                levelStaticData.PlatformColors = FindObjectsOfType<Platform>().Select(x => x.GetComponent<MeshRenderer>().sharedMaterial.color).ToArray();
                

                levelStaticData.HeroInitialPoint = GameObject.FindGameObjectWithTag(HeroInitialPointTag).transform.position;
                levelStaticData.LevelEndpoint = GameObject.FindGameObjectWithTag(LevelEndpointTag).transform.position;

                levelStaticData.StartColor = GameObject.FindGameObjectWithTag(InitialPlatformTag).GetComponent<MeshRenderer>().sharedMaterial.color;
                levelStaticData.LevelName = SceneManager.GetActiveScene().name;
            }
            
            EditorUtility.SetDirty(target);
        }
    }
}

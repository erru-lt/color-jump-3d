using Assets.Scripts.Logic.Platforms;
using Assets.Scripts.StaticData;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
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

            if (GUILayout.Button("Collect"))
            {               
                List<Color> colors = FindObjectsOfType<Platform>().Select(x => x.GetComponent<MeshRenderer>().sharedMaterial.color).ToList();

                ColorsList(levelStaticData, colors);

                levelStaticData.HeroInitialPoint = GameObject.FindGameObjectWithTag(HeroInitialPointTag).transform.position;
                levelStaticData.LevelEndpoint = GameObject.FindGameObjectWithTag(LevelEndpointTag).transform.position;

                levelStaticData.StartColor = GameObject.FindGameObjectWithTag(InitialPlatformTag).GetComponent<MeshRenderer>().sharedMaterial.color;
                levelStaticData.LevelName = SceneManager.GetActiveScene().name;
            }

            EditorUtility.SetDirty(target);
        }

        private static void ColorsList(LevelStaticData levelStaticData, List<Color> colors)
        {
            int index = 0;
            foreach (Color color in colors)
            {
                if (levelStaticData.PlatformColors.Contains(color) == false)
                {
                    levelStaticData.PlatformColors.Add(color);
                }
                
                index++;
            }
        }
    }
}

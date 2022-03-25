using UnityEngine;
using UnityEditor;
using Assets.Scripts.StaticData;
using Assets.Scripts.Logic;
using System.Linq;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Editor
{
    [CustomEditor(typeof(LevelStaticData))]
    public class LevelStaticDataEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            LevelStaticData levelStaticData = (LevelStaticData)target;

            if(GUILayout.Button("Collect"))
            {
                levelStaticData.PlatformColors = FindObjectsOfType<Platform>().Select(x => x.GetComponent<MeshRenderer>().material.color).ToArray();

                levelStaticData.StartColor = GameObject.FindGameObjectWithTag("InitialPlatform").GetComponent<MeshRenderer>().material.color;
                levelStaticData.LevelName = SceneManager.GetActiveScene().name;
            }

            EditorUtility.SetDirty(target);
        }
    }
}

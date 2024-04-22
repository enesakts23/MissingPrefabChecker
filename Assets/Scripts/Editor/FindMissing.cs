#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;


/*
 * Author = https://github.com/enesakts23
 * If you are going to obtain the output of the dedicated server, make sure to add #if UNITY_EDITOR at the beginning of the script and #endif at the end. This way, you won't encounter any errors while obtaining the output.
 */


namespace Enes.Scripts.Editor 
{
    public class FindMissing
    {
        [MenuItem("Prefab Checker/Find in current project")]
        static void FindProjectMenuItem()
        {
            string[] prefabPaths = AssetDatabase.GetAllAssetPaths().Where(path => path.EndsWith(".prefab", System.StringComparison.OrdinalIgnoreCase)).ToArray();
            
            foreach (string path in prefabPaths)
            {
                GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>(path);

                foreach (Component component in prefab.GetComponentsInChildren<Component>())
                {
                    if (component == null)
                    {
                        //Debug.Log("Prefab'ta eksik script mevcut: " + path, prefab);
                        break;
                    }
                    else
                    {
                        //Debug.Log("eksik script yok.");
                    }
                }
            }
        }

        [MenuItem("Prefab Checker/Find in current scene")]

        static void FindMissingScriptsInScene()
        {
            foreach (GameObject gameObject in GameObject.FindObjectsOfType<GameObject>(true))
            {
                foreach (Component component in gameObject.GetComponentsInChildren<Component>())
                {
                    if (component == null)
                    {
                        //Debug.Log("Missing" + gameObject.name, gameObject);
                        break;
                    }
                }
            }
        }
    }
}
#endif

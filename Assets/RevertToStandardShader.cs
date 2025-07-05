/*using UnityEngine;
using UnityEditor;

public class RevertToStandardShader : MonoBehaviour
{
    [MenuItem("Tools/Revert All URP Materials to Standard")]
    static void RevertShaders()
    {
        string[] guids = AssetDatabase.FindAssets("t:Material");
        foreach (string guid in guids)
        {
            string path = AssetDatabase.GUIDToAssetPath(guid);
            Material mat = AssetDatabase.LoadAssetAtPath<Material>(path);

            if (mat.shader.name.Contains("Universal Render Pipeline"))
            {
                Debug.Log("Reverting shader: " + mat.name);
                mat.shader = Shader.Find("Standard");
            }
        }

        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }
}
*/
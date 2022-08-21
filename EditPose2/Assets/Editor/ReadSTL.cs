using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

[CustomEditor(typeof(DefaultAsset))]

public class ReadSTL : Editor
{
    public override void OnInspectorGUI()
    {
        //if (AssetDatabase.GetAssetPath(target).IsStl())
        //{
        //    ShowUI();
        //}
    }
}


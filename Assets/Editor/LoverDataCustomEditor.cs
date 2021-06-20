using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEditor.Callbacks;

public class AssetHandler
{
    [OnOpenAsset()]
    public static bool OpenEditor(int instanceId, int line)
    {
        LoverData loverData = EditorUtility.InstanceIDToObject(instanceId) as LoverData;
        if (loverData != null)
        {
            LoverEditorWindow.Open(loverData);
            return true;
        }
        return false;
    }
}

[CustomEditor(typeof(LoverData))]
public class LoverDataCustomEditor : Editor
{

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (GUILayout.Button("Open Editor"))
        {
            LoverEditorWindow.Open((LoverData)target);
        }
    }
}

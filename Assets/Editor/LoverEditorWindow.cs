using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class LoverEditorWindow : ExtendedEditorWindow
{
    public static void Open(LoverData _loveDataObject)
    {
        LoverEditorWindow window = GetWindow<LoverEditorWindow>("Lover Data Editor");
        window.serializedObject = new SerializedObject(_loveDataObject);
    }

    void OnGUI()
    {

        currentProperty = serializedObject.FindProperty("couples");

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.BeginVertical("box", GUILayout.MaxWidth(150), GUILayout.ExpandHeight(true));
        GUILayout.Label("Couples");
        DrawSideBar(currentProperty);
        EditorGUILayout.BeginHorizontal("box");
        if (GUILayout.Button("Add Couple"))
        {
            currentProperty.InsertArrayElementAtIndex(0);
        }
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.EndVertical();

        EditorGUILayout.BeginVertical("box", GUILayout.ExpandHeight(true));
        if (selectedProperty != null)
        {
            DrawProperties(selectedProperty, true);
            
        }
        else
        {
            EditorGUILayout.LabelField("Select an item from the list");
        }
        EditorGUILayout.EndVertical();
        EditorGUILayout.EndHorizontal();
    }
}

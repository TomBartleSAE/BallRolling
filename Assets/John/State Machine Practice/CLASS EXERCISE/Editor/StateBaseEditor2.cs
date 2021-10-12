using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(StateBase2), true)]

public class StateBaseEditor2 : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (GUILayout.Button("Enter State"))
        {
            (target as StateBase2)?.Enter();
        }

        if (GUILayout.Button("Exit State"))
        {
            (target as StateBase2)?.Exit();
        }

        if (GUILayout.Button("Execute State"))
        {
            (target as StateBase2)?.Execute();
        }
    }
}

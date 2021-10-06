using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(RootObject))]

public class StateBaseEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (GUILayout.Button("Second Test State"))
        {
            (target as RootObject)?.GetComponent<StateManager>().ChangeState((target as RootObject).secondState);
        }

        if (GUILayout.Button("Test State"))
        {
            (target as RootObject)?.GetComponent<StateManager>().ChangeState((target as RootObject).firstState);
        }
    }
}

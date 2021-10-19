using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GameManager), true)]

public class StateBaseEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (GUILayout.Button("InGameState"))
        {
            GameManager gm = target as GameManager;
            gm?.GetComponent<StateManager>().ChangeState(gm.inGameState);
        }

        if (GUILayout.Button("InMenuState"))
        {
            GameManager gm = target as GameManager;
            gm?.GetComponent<StateManager>().ChangeState(gm.inMenuState);
        }
    }
}

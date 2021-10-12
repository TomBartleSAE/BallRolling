using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(NewStateManager))]

public class NewStateManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (GUILayout.Button("Change State"))
        {
            //Initializing variable
            NewStateManager myStateManager = target as NewStateManager;

            myStateManager?.ChangeState(myStateManager.nextStateTest);


            //LONG VERSION
                //(target as NewStateManager)?.ChangeState((target as NewStateManager).nextStateTest);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(RollingBallModel))]

public class BallSize_Editor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

		if (GUILayout.Button("SML Debris"))
		{
			(target as RollingBallModel)?.ChangeSize(0.1f);
		}

		if (GUILayout.Button("MED Debris"))
		{
			(target as RollingBallModel)?.ChangeSize(0.2f);
		}

		if (GUILayout.Button("LRG Debris"))
		{
			(target as RollingBallModel)?.ChangeSize(0.3f);
		}

		if (GUILayout.Button("Minus SML Debris"))
		{
			(target as RollingBallModel)?.ChangeSize(-0.1f);
		}

		if (GUILayout.Button("Minus MED Debris"))
		{
			(target as RollingBallModel)?.ChangeSize(-0.2f);
		}

		if (GUILayout.Button("Minus LRG Debris"))
		{
			(target as RollingBallModel)?.ChangeSize(-0.3f);
		}
	}
}

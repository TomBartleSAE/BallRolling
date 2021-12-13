using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(RollingBall_ViewModel))]

public class RollingBall_ViewModel_Editor : Editor
{
	GameObject gm;
	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI();

		if (GUILayout.Button("Test Death EFX"))
		{
			(target as RollingBall_ViewModel)?.DeathEffects(gm);
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(HealthModel))]

public class Health_Editor : Editor
{
	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI();

		if (GUILayout.Button("Die Button"))
		{
			(target as HealthModel)?.DeathButton();
		}

		if (GUILayout.Button("Max Health Button"))
		{
			(target as HealthModel)?.MaxHealthButton();
		}
	}
}

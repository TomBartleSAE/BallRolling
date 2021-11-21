using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SpawnerEditorWindow : EditorWindow
{
    //Variables
    //AREA TO SPAWN
    Vector2Int xRange;
    Vector2Int zRange;
    int scale = 20;
    float spawnThreshold = 0.85f;
    float spawnHeight = 0f;

    public Object objectsToSpawn;

    bool groupEnabled = false;

    // Add menu to the tools menu
    [MenuItem("Tools/Debris Spawner")]
    static void Init()
    {
        // Get existing open window or if none, make a new one:
        SpawnerEditorWindow window = (SpawnerEditorWindow)EditorWindow.GetWindow(typeof(SpawnerEditorWindow));
        window.Show();
    }

    void OnGUI()
    {
        GUILayout.Label("Debris Type:", EditorStyles.boldLabel);

        if (objectsToSpawn != null)
        {
            objectsToSpawn = EditorGUI.ObjectField(Rect.MinMaxRect(100, 0, 300, 16), ((GameObject)objectsToSpawn).name, objectsToSpawn, typeof(GameObject), true);
        }
        else
        {
            objectsToSpawn = EditorGUI.ObjectField(Rect.MinMaxRect(100, 0, 300, 16), objectsToSpawn, typeof(GameObject), true);
        }

        GUILayout.Space(3f);
        GUILayout.Label("Specifications:", EditorStyles.boldLabel);

        xRange = EditorGUILayout.Vector2IntField("X Range:", xRange);
        zRange = EditorGUILayout.Vector2IntField("Z Range:", zRange);

        scale = EditorGUILayout.IntField("Scale", scale);

        groupEnabled = EditorGUILayout.BeginToggleGroup("More Options", groupEnabled);
        spawnHeight = EditorGUILayout.FloatField("Spawn Height", spawnHeight);
        spawnThreshold = EditorGUILayout.FloatField("Spawn Threshold", spawnThreshold);
        EditorGUILayout.EndToggleGroup();

        //Revert GO's Back to Old GO's (Only Works if GO's havent been destroyed)
        if (GUILayout.Button("Spawn Debris"))
        {
            if (objectsToSpawn == null)
            {
                Debug.Log("No Prefab");
                return;
            }

            for (int x = xRange.x; x < xRange.y; x++)
            {
                for (int y = zRange.x; y < zRange.y; y++)
                {
                    float xCoord = (float)x / (xRange.y - xRange.x) * scale;
                    float yCoord = (float)y / (zRange.y - zRange.x) * scale;

                    float perlinValue = Mathf.PerlinNoise(xCoord, yCoord);

                    if (perlinValue > spawnThreshold)
                    {
                        //GameObject randomObject = objectsToSpawn[Random.Range(0, objectsToSpawn.Length)];
                        GameObject newObject = PrefabUtility.InstantiatePrefab(objectsToSpawn) as GameObject;
                        newObject.transform.position = new Vector3(x, spawnHeight, y);
                    }
                }
            }
        }

    }
}

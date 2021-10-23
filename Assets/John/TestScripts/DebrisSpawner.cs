using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebrisSpawner : MonoBehaviour
{
    public int width = 100;
    public int height = 100;

    public int scale = 5;

    public GameObject[] debrisTypes;

    // Start is called before the first frame update
    void Start()
    {
        for(int x = 0; x < width; x++)
        {
            for(int y = 0; y < height; y++)
            {
                float xCoord = (float) x / width * scale;
                float yCoord = (float) y / height * scale;

                float perlinValue = Mathf.PerlinNoise(xCoord, yCoord);

                if(perlinValue > 0.5)
                {
                    
                    if(Random.Range(0,20) == 1)
                    {
                        GameObject randomDebris = debrisTypes[Random.Range(0, debrisTypes.Length)];
                        Instantiate(randomDebris, new Vector3(x, perlinValue, y), Quaternion.identity);
                    }
                    

                    //Instantiate(cube, new Vector3(x, perlinValue, y), Quaternion.identity);

                }
            }
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelReference : MonoBehaviour, ITweenable
{
    public string levelID;

    public void PlayTween()
    {
        Debug.Log("Do my Tween FOR" + levelID);
    }
}

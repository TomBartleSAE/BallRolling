using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LevelReference : MonoBehaviour, ITweenable
{
    //public because we need to reference this from outside of the script to load the level
    public string levelID;

    [SerializeField]
    float scaleSize = 1.2f;

    [SerializeField]
    float scaleTime = 0.25f;

    public void PlayTween()
    {
        transform.DOScale(scaleSize, scaleTime);
    }

    public void ResetTween()
    {
        transform.DOScale(1f, scaleTime);
    }
}

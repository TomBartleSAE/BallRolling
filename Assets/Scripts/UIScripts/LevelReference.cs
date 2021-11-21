using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class LevelReference : MonoBehaviour, ISelectable
{
    [Header("Level Reference")]
    [SerializeField]
    string levelID;

    [Header("Tween Variables")]
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

    //Load level using this objects unique level reference
    public void Interaction()
    {
        GameManager.Instance.LoadLevel(levelID);
    }
}

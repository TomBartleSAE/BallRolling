using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BackButtonModel : MonoBehaviour, ISelectable
{
    [Header("Menu References - Does not need a previous menu")]
    [SerializeField]
    GameObject myMenu;
    [SerializeField]
    GameObject previousMenu;

    [Header("Tween Values")]
    [SerializeField]
    float scaleSize = 1.2f;
    [SerializeField]
    float scaleTime = 0.25f;

    public void Interaction()
    {
        myMenu.SetActive(false);

        //Only turn on other menu if one is given
        if(previousMenu != null)
        {
            previousMenu.SetActive(true);
        }
    }

    public void PlayTween()
    {
        transform.DOScale(scaleSize, scaleTime);
    }

    public void ResetTween()
    {
        transform.DOScale(1f, scaleTime);
    }
}

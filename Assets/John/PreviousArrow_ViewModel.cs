using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PreviousArrow_ViewModel : MonoBehaviour
{
    [Header("Tween Values")]
    [SerializeField]
    float scaleSize = 2f;
    [SerializeField]
    float scaleTime = 0.5f;

    Sequence previousArrowSequence;

    // Start is called before the first frame update
    void Start()
    {
        previousArrowSequence = DOTween.Sequence();

        //lobbyPlayer = FindObjectOfType<LobbyPlayer>();
        //LobbyPlayer.PreviousButtonEvent += PreviousArrowPressed;
    }

    void PreviousArrowPressed()
    {
        previousArrowSequence.Append(transform.DOScale(scaleSize, scaleTime));
        previousArrowSequence.Append(transform.DOScale(1f, scaleTime));
    }
}

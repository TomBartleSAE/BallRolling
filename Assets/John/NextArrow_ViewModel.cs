using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class NextArrow_ViewModel : MonoBehaviour
{
    [Header("Tween Values")]
    [SerializeField]
    float scaleSize = 2f;
    [SerializeField]
    float scaleTime = 0.5f;

    Sequence nextArrowSequence;

    //public LobbyPlayer lobbyPlayer;

    // Start is called before the first frame update
    void Start()
    {
        nextArrowSequence = DOTween.Sequence();

        //lobbyPlayer = FindObjectOfType<LobbyPlayer>();
        //LobbyPlayer.NextButtonEvent += NextArrowPressed;
    }

    void NextArrowPressed()
    {
        nextArrowSequence.Append(transform.DOScale(scaleSize, scaleTime));
        nextArrowSequence.Append(transform.DOScale(1f, scaleTime));
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class EndScreenManager : MonoBehaviour
{
    public TMP_Text whoWonText;
    public MeshRenderer skin;
    public Material aiSkin;

    private void Start()
    {
        if (GameManager.Instance.winningBall != null)
        {
            skin.material = GameManager.Instance.winningBall.GetComponentInChildren<MeshRenderer>().material;
            whoWonText.text = "YOU WON!!";
        }
        else
        {
            skin.material = aiSkin;
            whoWonText.text = "COMPUTER WINS";
        }

        //EFX:
        //whoWonText.transform.DOLocalJump(new Vector3(0, whoWonText.transform.position.y + 50f, 0), 5f, 5, 2f);
    }
}

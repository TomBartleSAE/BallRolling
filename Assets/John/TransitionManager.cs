using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TransitionManager : MonoBehaviour
{
    public Image fader;
    public bool transitionComplete = false;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.transition = this;

        fader.gameObject.SetActive(true);
        fader.DOFade(0, 3f);
        transitionComplete = false;
    }

    public void NewSceneTransition()
    {
        fader.DOFade(1, 3f).OnComplete(TransitionComplete);
    }

    void TransitionComplete()
    {
        transitionComplete = true;
    }

}

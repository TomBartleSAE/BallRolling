using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FlipperModel : MonoBehaviour
{
    [SerializeField]
    float reachTarget;
    [SerializeField]
    int resetTarget;
    [SerializeField]
    float accelerationSpeed;
    [SerializeField]
    float resetSpeed;

    float rotation;

    // Start is called before the first frame update
    void Start()
    {
        LaunchFlipper();
    }

    float GetPosition()
    {
        return rotation;
    }

    void SetLaunchPosition(float newPosition)
    {
        rotation = newPosition;
        transform.localRotation = Quaternion.Euler(0, newPosition, 0);
    }

    void LaunchFlipper()
    {
        DOTween.To(GetPosition, SetLaunchPosition, reachTarget, accelerationSpeed).SetEase(Ease.OutElastic).OnComplete(ResetFlipper);
    }

    void ResetFlipper()
    {
        DOTween.To(GetPosition, SetLaunchPosition, resetTarget, resetSpeed).OnComplete(LaunchFlipper);
    }
}

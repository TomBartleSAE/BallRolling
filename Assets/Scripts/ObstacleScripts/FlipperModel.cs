using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FlipperModel : MonoBehaviour
{
    [SerializeField]
    float forwardTarget;
    [SerializeField]
    int reverseTarget;

    Rigidbody rb;

    /*
    [SerializeField]
    float accelerationSpeed;
    [SerializeField]
    float resetSpeed;

    float rotation;
    */

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        LaunchFlipper();
    }

    /*
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
    */

    void LaunchFlipper()
    {
        rb.DORotate(new Vector3(0, forwardTarget, 0), 1f, RotateMode.Fast).SetEase(Ease.OutElastic).OnComplete(ResetFlipper);
    }

    void ResetFlipper()
    {
        rb.DORotate(new Vector3(0, reverseTarget, 0), 1.5f, RotateMode.Fast).OnComplete(LaunchFlipper);
    }
}

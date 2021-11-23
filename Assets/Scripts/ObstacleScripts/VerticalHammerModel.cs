using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class VerticalHammerModel : MonoBehaviour
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
        SwingRight();
    }

    float GetPosition()
    {
        return rotation;
    }

    void SetSwingPosition(float newPosition)
    {
        rotation = newPosition;
        transform.localRotation = Quaternion.Euler(0, 0, newPosition);
    }

    void SwingRight()
    {
        DOTween.To(GetPosition, SetSwingPosition, reachTarget, accelerationSpeed).SetEase(Ease.InOutBack).OnComplete(SwingLeft);
    }

    void SwingLeft()
    {
        DOTween.To(GetPosition, SetSwingPosition, resetTarget, resetSpeed).SetEase(Ease.InOutBack).OnComplete(SwingRight);
    }
}

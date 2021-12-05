using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class VerticalHammerModel : MonoBehaviour
{
    [SerializeField]
    float forwardTarget;
    [SerializeField]
    int reverseTarget;
    //[SerializeField]
    //float accelerationSpeed;
    //[SerializeField]
    //float resetSpeed;

    float rotation;
    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Start is called before the first frame update
    void Start()
    {
        //SwingRight();

        ForwardSwing();
    }

    #region Old Rotation (Broken)
    /*
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
    */

    #endregion


    //Needed to use rigibid body instead to allow collisions with player (using transform.rotate caused clipping)
    void ForwardSwing()
    {
        rb.DORotate(new Vector3(0, 0, forwardTarget), 1f, RotateMode.Fast).SetEase(Ease.InOutBack).OnComplete(ReverseSwing);
    }

    void ReverseSwing()
    {
        rb.DORotate(new Vector3(0, 0, reverseTarget), 1f, RotateMode.Fast).SetEase(Ease.InOutBack).OnComplete(ForwardSwing);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITweenable
{
    void PlayTween();
    void ResetTween();
}

public interface IInteractable
{
    void Interact();
}

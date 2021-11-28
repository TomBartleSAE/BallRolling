using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMenu : MonoBehaviour
{
    public MeshRenderer playerModel;
    public Image readyIcon;

    public void SetSkin(Material newSkin)
    {
        playerModel.material = newSkin;
    }

    public void EnableReadyIcon(bool enabled)
    {
        readyIcon.enabled = enabled;
    }
}

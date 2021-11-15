using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMenu : MonoBehaviour
{
    public MeshRenderer playerModel;

    public void SetSkin(Material newSkin)
    {
        playerModel.material = newSkin;
    }
}

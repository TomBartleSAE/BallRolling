using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTarget : MonoBehaviour
{
    PlayerCameraModel myCam;


    //SET CAMERA TARGET
    public void SetMyCamera(PlayerCameraModel newCamera)
    {
        myCam = newCamera;
    }

    //GET CAM TARGET
    public PlayerCameraModel GetMyCamera()
    {
        return myCam;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class CameraController : NetworkBehaviour
{
    public GameObject cameraHolder;

    public void Start()
    {
        if (!IsLocalPlayer)
        {
            cameraHolder.SetActive(false);
        }
    }
}

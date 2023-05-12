using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCameraWithPlayer : MonoBehaviour
{
    public Transform cameraPos;
    void Update()
    {
        transform.position = cameraPos.position;
    }
}

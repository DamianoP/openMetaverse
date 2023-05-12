using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMousePosition : MonoBehaviour
{
    public Camera drawUICameraMarker;
    public Vector3 screenPosition;
    public Vector3 worldPosition;

    void Start()
    {
        
    }

    void Update()
    {
        //transform.position = drawUICameraMarker.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, drawUICameraMarker.nearClipPlane + 0.6f));
        screenPosition = Input.mousePosition;
        Ray ray = drawUICameraMarker.ScreenPointToRay(screenPosition);
        if (Physics.Raycast(ray, out RaycastHit hitData))
        {
            worldPosition = hitData.point;
        }

        transform.position = new Vector3(worldPosition.x - 0.1f, worldPosition.y, worldPosition.z);
    }
}

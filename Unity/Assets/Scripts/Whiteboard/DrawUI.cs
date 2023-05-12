using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class DrawUI : MonoBehaviour
{
    //public GameObject canvasUi;
    public static bool IsUIOpen;
    public GameObject drawCanvas;
    private bool collision;
    Camera playerCam;
    public Camera drawUICam;
    public GameObject markerMouse;
    public GameObject markerMouseCopy;
    Vector3 mousePosition;

    void Start()
    {
        playerCam = Resources.Load("Player 1").GetComponentInChildren<Camera>();
        collision = false;
        playerCam.enabled = true;
        drawUICam.enabled = false;
        
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.F) && collision)
        {
            IsUIOpen = !IsUIOpen;
        }      

        if (IsUIOpen)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            playerCam.enabled = false;
            drawUICam.enabled = true;
            drawCanvas.SetActive(true);
            if (Input.GetMouseButtonDown(0))
            {
                mousePosition = drawUICam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0.1f));
                markerMouseCopy = Instantiate(markerMouse, mousePosition, Quaternion.Euler(new Vector3(0,0,-90)));
            }
            if (Input.GetMouseButtonUp(0))
            {
                Destroy(markerMouseCopy);
            }
        }
        else if (IsUIOpen == false)
        {
            //Cursor.visible = false;
            //Cursor.lockState = CursorLockMode.Locked;
            playerCam.enabled = true;
            drawUICam.enabled = false;
            drawCanvas.SetActive(false);
        }
            
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            collision = true;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            collision = false;
        }
    }

}

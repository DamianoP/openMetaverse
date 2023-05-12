using UnityEngine;
using Unity.Netcode;


public class MovementNoVr : NetworkBehaviour
{
    [Header("Movement")]
    public float move_speed;
    public Transform orientation;
    float horizontalInput;
    float verticalInput;
    Vector3 moveDirection;
    public Rigidbody rb;
    public static bool isEducator;
    public static string username;
    public static AudioClip voiceToSend;
    public static byte[][] dividedAudioBytes2 = new byte[129][];

    private void Start()
    {
        rb.freezeRotation = true;
    }

    void Update()
    {

        if (!IsOwner)
        {
            return;
        }


        if (DrawUI.IsUIOpen == false && IsClient && !LobbyManager.IsLobbyOpen)
        {

            moveDirection = new Vector3(0, 0, 0);

            horizontalInput = Input.GetAxisRaw("Horizontal");
            verticalInput = Input.GetAxisRaw("Vertical");

            moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

            transform.position += moveDirection * move_speed * Time.deltaTime;

        }

        if (IsClient && DrawUI.IsUIOpen == false)
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                LobbyManager.IsLobbyOpen = !LobbyManager.IsLobbyOpen;
            }

            if (Input.GetKeyDown(KeyCode.Backslash))
            {
                StatInfoManager.IsInfoStatOpen = !StatInfoManager.IsInfoStatOpen;
            }

            if (LobbyManager.IsLobbyOpen)
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
            else if(!LobbyManager.IsLobbyOpen)
            {
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }

        }
    }

}

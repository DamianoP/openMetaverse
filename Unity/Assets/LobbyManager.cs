using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyManager : MonoBehaviour
{
    [SerializeField] private GameObject lobbyChat;
    public static bool IsLobbyOpen;

    void Start()
    {
        IsLobbyOpen = false;
    }

    void Update()
    {
        if (IsLobbyOpen)
        {
            lobbyChat.SetActive(true);
        }
        else if (!IsLobbyOpen)
        {
            lobbyChat.SetActive(false);
        }
    }
}

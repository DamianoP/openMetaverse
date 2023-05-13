using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class TestConnectionPhoton : MonoBehaviourPunCallbacks
{

    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("Joined the lobby");
    }
}

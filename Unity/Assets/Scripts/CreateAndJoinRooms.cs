using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateAndJoinRooms : MonoBehaviourPunCallbacks
{
    public static void CreateRoom()
    {
        try
        {
            PhotonNetwork.CreateRoom("Test");
        }
        catch (System.Exception)
        {
            Debug.Log("Error in creating a room");
            throw;
        }
    }

    public static void JoinRoom()
    {
        try
        {
            PhotonNetwork.JoinRoom("Test");
        }
        catch (System.Exception)
        {
            Debug.Log("Error in joining a room");
            throw;
        } 
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Joined the room");
    }

}

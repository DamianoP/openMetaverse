using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using UnityEngine;
using UnityEngine.UI;

public class ConnectClient : NetworkBehaviour
{
    [SerializeField] private TMP_InputField address;
    [SerializeField] private TMP_InputField port;
    [SerializeField] private TMP_Text addressStatUI;
    [SerializeField] private TMP_Text portStatUI;
    [SerializeField] private Button ConnectBtn;
    [SerializeField] private UnityTransport networkStat;
    

    private void Awake()
    {
        ConnectBtn.onClick.AddListener(() => {
            networkStat.ConnectionData.Address = address.text;

            networkStat.ConnectionData.Port = ushort.Parse(port.text);

            addressStatUI.text = "Address: " + networkStat.ConnectionData.Address;
            portStatUI.text = "Port: " + networkStat.ConnectionData.Port.ToString();
            NetworkManager.Singleton.StartClient();

            StartCoroutine(WaitForConnection());
        });
    }

    IEnumerator WaitForConnection()
    {
        yield return new WaitForSeconds(2);

        if (NetworkManager.Singleton.IsConnectedClient == false)
        {
            NetworkManager.Singleton.Shutdown();
        }
        else
        {
            CreateAndJoinRooms.JoinRoom();
        }
    }
}

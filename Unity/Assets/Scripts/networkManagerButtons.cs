using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Net;
using TMPro;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using UnityEngine;
using UnityEngine.UI;

public class networkManagerButtons : NetworkBehaviour
{
    [SerializeField] private Button HostBtn;
    [SerializeField] private Button ClientBtn;
    [SerializeField] private UnityTransport networkStat;
    [SerializeField] private GameObject SocketForClient;
    [SerializeField] private TMP_Text addressStatUI;
    [SerializeField] private TMP_Text portStatUI;


    private void Awake()
    {
        HostBtn.onClick.AddListener(() => {
            networkStat.ConnectionData.Address = GetLocalIPAddress();
            Debug.Log(GetLocalIPAddress());

            ushort random = (ushort)Random.Range(2000, 9000);
            networkStat.ConnectionData.Port = random;
            Debug.Log(random);

            addressStatUI.text = "Address: " + networkStat.ConnectionData.Address;
            portStatUI.text = "Port: " + networkStat.ConnectionData.Port.ToString();
            NetworkManager.Singleton.StartHost();

            CreateAndJoinRooms.CreateRoom();
        });

        ClientBtn.onClick.AddListener(() => {
            SocketForClient.SetActive(true);
        });
    }

    public string GetLocalIPAddress()
    {
        var host = Dns.GetHostEntry(Dns.GetHostName());
        foreach (var ip in host.AddressList)
        {
            if (ip.AddressFamily == AddressFamily.InterNetwork)
            {
                return ip.ToString();
            }
        }
        throw new System.Exception("No network adapters with an IPv4 address in the system!");
    }
}

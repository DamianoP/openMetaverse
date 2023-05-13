using System.Collections.Generic;
using TMPro;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class LobbyChatBehaviour : NetworkBehaviour
{
    [SerializeField] private Button SendBtn;
    [SerializeField] private TMP_Text messageField;
    [SerializeField] private TMP_InputField messageToSend;
    public bool isCommand = false;

    [System.Obsolete]
    private void Start()
    {
        SendBtn.onClick.AddListener(() => {
            string[] commandDivided = messageToSend.text.Split(' ');

            if (commandDivided.Length == 5 && commandDivided[0] == "/grade")
            {
                isCommand = true;
                Grade(commandDivided);
            }
            else
            {
                SendChatMessageServerRpc(MovementNoVr.username, messageToSend.text);
            }
        });
    }

    [System.Obsolete]
    private void Update()
    {
        string[] commandDivided = messageToSend.text.Split(' ');

        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (commandDivided.Length == 5 && commandDivided[0] == "/grade")
            {
                isCommand = true;
                Grade(commandDivided);
            }
            else
            {
                SendChatMessageServerRpc(MovementNoVr.username, messageToSend.text);
            }
        }
    }

    [System.Obsolete]
    public void Grade(string[] commandGrade)
    {
        if (MovementNoVr.isEducator)
        {
            if (isCommand)
            {
                StartCoroutine(UsersDatabase.GradeStudent(commandGrade[1], commandGrade[2], commandGrade[3], commandGrade[4]));
                isCommand = false;
            }
        }
    }

    [ServerRpc (RequireOwnership = false)]
    private void SendChatMessageServerRpc(string ClientId,string message)
    {
        ReceiveChatMessageClientRpc(ClientId, message);
    }

    [ClientRpc]
    private void ReceiveChatMessageClientRpc(string ClientId, string SenderMessage)
    {
        messageField.text = messageField.text + ClientId + ": " + SenderMessage + "\n";
    }
}



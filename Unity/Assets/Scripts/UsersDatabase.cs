using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class UsersDatabase : MonoBehaviour
{
    [SerializeField] private TMP_InputField username;
    [SerializeField] private TMP_InputField password;
    [SerializeField] private Button SendFormLogin;
    [SerializeField] private GameObject HostOrClient;
    [SerializeField] private GameObject SocketForClients;

    [System.Obsolete]
    void Start()
    {
        SendFormLogin.onClick.AddListener(() =>
        {
            StartCoroutine(Login(username.text, password.text));
        });
    }

    void Update()
    {
        
    }

    [System.Obsolete]
    IEnumerator Login(string username, string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("userLogin", username);
        form.AddField("passwdLogin", password);

        using (UnityWebRequest www = UnityWebRequest.Post("http://192.168.1.240/Thesis/Database.php", form))
        {
            yield return www.Send();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                string results = www.downloadHandler.text;

                if (results == "1")
                {
                    int index = username.IndexOf("@");
                    MovementNoVr.username = username.Substring(0, index);
                    MovementNoVr.isEducator = true;
                    HostOrClient.SetActive(true);
                }
                else if(results == "0")
                {
                    int index = username.IndexOf("@");
                    MovementNoVr.username = username.Substring(0, index);
                    MovementNoVr.isEducator = false;
                    SocketForClients.SetActive(true);
                }

            }
        }
    }

    [System.Obsolete]
    public static IEnumerator GradeStudent(string name, string surname, string subject, string grade)
    {
        WWWForm forms = new WWWForm();
        forms.AddField("name", name);
        forms.AddField("surname", surname);
        forms.AddField("subject", subject);
        forms.AddField("grade", grade);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/Thesis/Grade.php", forms))
        {
            yield return www.Send();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log("Successfully graded");
            }
        }
    }
}

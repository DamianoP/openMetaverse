using Photon.Voice.PUN;
using Photon.Voice.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushToTalkPhoton : MonoBehaviour
{
    private Recorder recorder;
    private Recorder recorderTTS;
    private PunVoiceClient punVoiceClient;

    void Start()
    {
        recorder = GameObject.Find("VoiceManagerPhoton").GetComponent<Recorder>();      
        recorderTTS = GameObject.Find("VoiceManagerTTS").GetComponent<Recorder>();
        punVoiceClient = GameObject.Find("VoiceManagerPhoton").GetComponent<PunVoiceClient>();

        punVoiceClient.AddRecorder(recorder);
        punVoiceClient.AddRecorder(recorderTTS);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            recorder.TransmitEnabled = true; 
        }
        else if (Input.GetKeyUp(KeyCode.M))
        {
            recorder.TransmitEnabled = false;
        }
    }

}

using Photon.Voice.Unity;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class TestToSpeech : MonoBehaviour
{
    [SerializeField] private UnityEngine.UI.Button textToWavBtn;
    [SerializeField] private TMP_InputField textToConvertAudio;
    private AudioSource playerSpeaker;
    [SerializeField] Recorder RecForAudioToSend;

    [System.Obsolete]
    private void Awake()
    {
        playerSpeaker = GameObject.Find("TestAudio").GetComponent<AudioSource>();

        textToWavBtn.onClick.AddListener(() => {
            SpeechGeneration_Editor2.TextToAudio("Lorenzo", textToConvertAudio.text, "AudioToSend", 0, "kGOdv5yl.oqUd2gMibwhBVp5C6ed57Wpxvs2LUKOW", playerSpeaker);
            RecForAudioToSend.AudioClip = playerSpeaker.clip;
        });
        
    }

    private void PlayAudioToSend()
    {
        playerSpeaker.Play();
    }

}

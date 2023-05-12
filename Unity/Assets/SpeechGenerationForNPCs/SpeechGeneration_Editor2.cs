using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Diagnostics;
using System.Net;
using System.Net.Http.Headers;
using System;
using System.IO;
using System.Text;
using TMPro;
using System.Threading;
using System.Linq;
using UnityEngine.UIElements;

public class Tts
{
    public string Phrase;

    public double Octave;

    public string Email;
    
    public string Title;

    public Dictionary<string, string[]> Options = new Dictionary<string, string[]>
    {
        { "Arabic",new string[] { "Farah", } },
        { "Chinese (Mandarin)",new string[] { "Daiyu", } },
        { "Danish",new string[] { "Emma", "Oscar", } },
        { "Dutch",new string[] { "Anke","Adriaan", } },
        { "English (Australian)",new string[] { "Mia","Grace","Jack", } },
        { "English (British)",new string[] { "Charlotte","Sophia","Elijah", } },
        { "English (Indian)",new string[] { "Advika","Onkar", } },
        { "English (New Zealand)",new string[] { "Ruby", } },
        { "English (South African)",new string[] { "Elna", } },
        { "English (US)",new string[] { "Mary","Linda","Patricia","Barbara","Susan","Paul","Michael","William","Thomas", } },
        { "English (Welsh)",new string[] { "Aeron", } },
        { "French",new string[] { "Capucine","Alix","Arnaud", } },
        { "French (Canadian)",new string[] { "Stephanie","Celine", } },
        { "German",new string[] { "Maria","Theresa","Felix", } },
        { "Hindi",new string[] { "Chhaya", } },
        { "Icelandic",new string[] { "Anna","Sigriour", } },
        { "Italian",new string[] { "Gabriella","Bella","Lorenzo", } },
        { "Japanese",new string[] { "Rika","Tanaka", } },
        { "Korean",new string[] { "Ji-Ho", } },
        { "Norwegian",new string[] { "Camilla", } },
        { "Polish",new string[] { "Katarzyna","Malgorzata","Piotr","Jan", } },
        { "Portuguese (Brazilian)",new string[] { "Tabata","Juliana","Pedro", } },
        { "Portuguese (European)",new string[] { "Pati","Adriano", } },
        { "Romanian",new string[] { "Alexandra", } },
        { "Russian",new string[] { "Inessa","Viktor", } },
        { "Spanish (European)",new string[] { "Francisca","Margarita","Mateo", } },
        { "Spanish (Mexican)",new string[] { "Leticia", } },
        { "Spanish (US)",new string[] { "Josefina","Rosa","Miguel", } },
        { "Swedish",new string[] { "Eva", } },
        { "Turkish",new string[] { "Mesut", } },
        { "Welsh",new string[] { "Angharad", } },
    };

    public string[] Langues = new string[]
        {
            "Arabic", "Chinese (Mandarin)", "Danish", "Dutch", "English (Australian)", "English (British)", "English (Indian)", "English (New Zealand)", "English (South African)", "English (US)", "English (Welsh)", "French", "French (Canadian)", "German", "Hindi", "Icelandic", "Italian", "Japanese", "Korean", "Norwegian", "Polish", "Portuguese (Brazilian)", "Portuguese (European)", "Romanian", "Russian", "Spanish (European)", "Spanish (Mexican)", "Spanish (US)", "Swedish", "Turkish", "Welsh",
        };
    
    public int Selected_O = 0;
    public int Selected_L = 0;
}
public class Synthese
{
    public string sentence;
    public string audio;

}
public class Authorization
{
    public string api_key = "kGOdv5yl.oqUd2gMibwhBVp5C6ed57Wpxvs2LUKOW";

}

public class SpeechGeneration_Editor2 : MonoBehaviour
{
    private Tts _tts = new Tts();

    public static string url;
    static UnityWebRequest www;

    public AudioClip son_pilou;

    private static Synthese info = null;

    static string s_octave;

    int selectedOctave = 0;
    string[] selStrings = { "normal pitch (0)", "low pitch (-0.5)", "high pitch (+0.5)", "custom pitch between -1 and +1" };

    [System.Obsolete]
    public static void TextToAudio(string option, string phrase, string title, double octave, string apikey, AudioSource testAudioSource)
    {
        if (apikey == null)
        {
            UnityEngine.Debug.LogError("Please contact the support");
            return;
        }

        if (phrase == null || phrase == "")
        {
            UnityEngine.Debug.LogError("Text is empty");
            return;
        }
        www = null;
        
        WWWForm form = new WWWForm();
        form.AddField("sentence", phrase);
        s_octave = octave.ToString();
        form.AddField("octave", s_octave.Replace(',', '.'));
        string lien = $"https://ariel-api.xandimmersion.com/tts/{option}";
        www = UnityWebRequest.Post(lien, form);
        www.SetRequestHeader("Authorization", "Api-Key " + apikey);

        www.SendWebRequest();
        while (!www.isDone)
        {
            continue;
        }

        if (www.result != UnityWebRequest.Result.Success)
        {
            UnityEngine.Debug.LogError("Error While Sending: " + www.error);
        }
        else
        {
            info = JsonUtility.FromJson<Synthese>(www.downloadHandler.text);
       
        }

        url = "https://rocky-taiga-14840.herokuapp.com/" + info.audio;
        using (UnityWebRequest www_audio = UnityWebRequestMultimedia.GetAudioClip(info.audio, AudioType.WAV))
        {
            www_audio.SetRequestHeader("x-requested-with", "http://127.0.0.1:8080");

            www_audio.SendWebRequest();


            while (!www_audio.isDone)
            {
                continue;
            }


            if (www_audio.isNetworkError)
            {
                UnityEngine.Debug.LogError(www_audio.error);
            }
            else
            {
                AudioClip son_pilou = DownloadHandlerAudioClip.GetContent(www_audio);
                testAudioSource.clip = son_pilou;

                if (title == null) 
                {
                    UnityEngine.Debug.Log("No file name : file will be saved at untitled-gen.wav");
                    title = "untitled";
                }

            }
        }

        info = null;

    }
    
}

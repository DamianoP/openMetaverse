using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatInfoManager : MonoBehaviour
{
    [SerializeField] private GameObject statInfo;
    public static bool IsInfoStatOpen = false;

    void Start()
    {
        
    }

    void Update()
    {
        if (IsInfoStatOpen)
        {
            statInfo.SetActive(true);
        }
        else if(!IsInfoStatOpen)
        {
            statInfo.SetActive(false);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slider_Marker_Size : MonoBehaviour
{

    [SerializeField] private Slider slider;
    public WhiteboardMarker marker;

    void Start()
    {
        UpdateSize(slider.value);
        slider.onValueChanged.AddListener(UpdateSize);
    }

    void UpdateSize(float val)
    {
        marker.ChangeTipSize((int)slider.value);
    }

}

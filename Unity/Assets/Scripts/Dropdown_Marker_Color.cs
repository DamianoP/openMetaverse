using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropdown_Marker_Color : MonoBehaviour
{
    [SerializeField] private MeshRenderer marker_tip_rendered;
    [SerializeField] private Material marker_tip_material;
    
    public void Dropdown(int index)
    {
        switch (index)
        {
            case 0:
                marker_tip_material.color = Color.blue;
                marker_tip_rendered.sharedMaterial.color = Color.blue;
                
                break;
            case 1:
                marker_tip_material.color = Color.red;
                marker_tip_rendered.sharedMaterial.color = Color.red;
                break;
            case 2:
                marker_tip_material.color = Color.yellow;
                marker_tip_rendered.sharedMaterial.color = Color.yellow;
                break;
        }
    }
}

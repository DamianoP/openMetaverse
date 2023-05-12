using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineGenerator : MonoBehaviour
{
    public GameObject lineFrefab;
    Line activeLine;
    public Camera noVrDrawCamera;
    public GameObject DrawUI;

    void Update()
    {
        if (DrawUI.activeSelf)
        {
            if (Input.GetMouseButtonDown(0))
            {
                GameObject nweLine = Instantiate(lineFrefab);
                activeLine = nweLine.GetComponent<Line>();
            }

            if (Input.GetMouseButtonUp(0))
            {
                activeLine = null;
            }

            if (activeLine != null)
            {
                Vector2 mousePos = noVrDrawCamera.ScreenToWorldPoint(Input.mousePosition);
            }
        }
    }
}

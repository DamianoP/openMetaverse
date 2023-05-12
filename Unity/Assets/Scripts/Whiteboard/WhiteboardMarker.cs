using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WhiteboardMarker : MonoBehaviour
{
    [SerializeField] private Transform tip;
    static private int pensize = 10;

    private Renderer render;
    private Color[] colors;
    private float tipheight;
    private RaycastHit touch;
    private Whiteboard whiteboard;
    private Vector2 touchposition, lasttouchedposition;
    private bool touchedlastframe;
    private Quaternion lasttouchedrotation;

    void Start()
    {
        render = tip.GetComponent<Renderer>();
        colors = Enumerable.Repeat(render.material.color, pensize * pensize).ToArray();
        tipheight = tip.localScale.y;
    }

    void Update()
    {
        Draw();
        UpdateColorOrSize();
    }

    public void ChangeTipSize(int new_size)
    {
        pensize = new_size;
    }

    public void Draw()
    {
        if (Physics.Raycast(tip.position, transform.up, out touch, tipheight))
        {
            if (touch.transform.CompareTag("Whiteboard"))
            {
                if(whiteboard == null)
                {
                    whiteboard = touch.transform.GetComponent<Whiteboard>();
                }

                touchposition = new Vector2(touch.textureCoord.x, touch.textureCoord.y);
                var x = (int)(touchposition.x * whiteboard.texturesize.x - (pensize/2));
                var y = (int)(touchposition.y * whiteboard.texturesize.y - (pensize/2));

                if (y < 0 || y > whiteboard.texturesize.y || x < 0 || x > whiteboard.texturesize.x)
                {
                    return;
                }

                if (touchedlastframe)
                {
                    whiteboard.texture.SetPixels(x, y, pensize, pensize, colors);

                    for (float f = 0.01f; f < 1.00f; f += 0.01f)
                    {
                        var lerpX = (int)Mathf.Lerp(lasttouchedposition.x, x, f);
                        var lerpY = (int)Mathf.Lerp(lasttouchedposition.y, y, f);
                        whiteboard.texture.SetPixels(lerpX, lerpY, pensize, pensize, colors);
                    }

                    transform.rotation = lasttouchedrotation;
                    whiteboard.texture.Apply();
                }

                lasttouchedposition = new Vector2(x, y);
                lasttouchedrotation = transform.rotation;
                touchedlastframe = true;
                return;
            }
        }

        whiteboard = null;
        touchedlastframe = false;
    }

    public void UpdateColorOrSize()
    {
        colors = Enumerable.Repeat(render.material.color, pensize * pensize).ToArray();
    }

    private void OnApplicationQuit()
    {

    }

}

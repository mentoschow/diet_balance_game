using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    public Canvas sc_canvas;
    public SelectCharacter sc;
    public Canvas performance_canvas;
    public Performance pf;
    public Canvas fs_canvas;

    void Start()
    {
        sc_canvas.enabled = true;
        performance_canvas.enabled = false;
        fs_canvas.enabled = false;
    }

    void Update()
    {
        if (sc.next == true)
        {
            sc_canvas.enabled = false;
            performance_canvas.enabled = true;
        }
        if (pf.next == true)
        {
            performance_canvas.enabled = false;
            fs_canvas.enabled = true;
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Performance : MonoBehaviour
{
    public AVGMachine avg;
    public bool next;

    void Start()
    {
        next = false;
    }

    void Update()
    {
        if (!next)
        {
            if (Input.GetKeyDown(KeyCode.H))
            {
                avg.startAVG();
            }
            if (Input.GetMouseButtonDown(0))
            {
                avg.userClicked();
            }
        }
    }
}

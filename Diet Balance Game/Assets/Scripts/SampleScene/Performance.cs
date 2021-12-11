using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Performance : MonoBehaviour
{
    public AVGMachine avg;
    public bool next;
    public Age_input ai;
    private bool frist;

    void Start()
    {
        next = false;
        frist = true;

    }

    void Update()
    {
        if (!next)
        {
            if (ai.next && frist)
            {
                avg.startAVG();
                frist = false;
            }
            if (Input.GetMouseButtonDown(0))
            {
                avg.userClicked();
            }
        }
    }
}

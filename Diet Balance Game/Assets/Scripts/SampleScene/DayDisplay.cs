using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayDisplay : MonoBehaviour
{
    public bool next = false;
    public Result result;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(result.next)
        {
            if (Input.GetMouseButtonDown(0))
            {
                next = true;
            }
        }
    }
}

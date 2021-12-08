using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSelection : MonoBehaviour
{
    public Canvas fs;
    public Canvas next;  //last scene
    public PlayerManager pm;

    void Start()
    {
        Init();
    }

    void Update()
    {
        
    }

    public void Init()
    {
        fs.enabled = false;
    }
}

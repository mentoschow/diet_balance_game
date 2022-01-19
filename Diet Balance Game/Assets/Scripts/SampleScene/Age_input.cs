using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class Age_input : MonoBehaviour
{
    public PlayerManager pm;
    public bool next = false;

    public InputField inputField;
    private Text txt;

    

    public void Input_Age()
    {
        pm.hero.age = inputField.text;
        next = true;
    }

    
}

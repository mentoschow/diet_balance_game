using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCharacter : MonoBehaviour
{
    public bool next = false;
    public PlayerManager pm;

    public void SelectBoy()
    {
        pm.isboy = true;
        next = true;
    }

    public void SelectGirl()
    {
        pm.isboy = false;
        next = true;
    }
}

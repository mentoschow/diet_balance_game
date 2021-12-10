using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCharacter : PlayerManager
{
    public bool next = false;

    public void SelectBoy()
    {
        isboy = true;
        next = true;
    }

    public void SelectGirl()
    {
        isboy = false;
        next = true;
    }
}

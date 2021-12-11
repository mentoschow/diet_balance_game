using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCharacter : PlayerManager
{
    public bool next = false;

    public void SelectBoy()
    {
        hero.isboy = true;
        next = true;
    }

    public void SelectGirl()
    {
        hero.isboy = false;
        next = true;
    }
}

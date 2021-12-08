using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCharacter : PlayerManager
{
    public Canvas select;

    public void SelectBoy()
    {
        isboy = true;
        select.enabled = false;
    }

    public void SelectGirl()
    {
        isboy = false;
        select.enabled = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCharacter : MonoBehaviour
{
    public bool isBoy;
    public Canvas select;

    public void SelectBoy()
    {
        isBoy = true;
        select.enabled = false;
    }

    public void SelectGirl()
    {
        isBoy = false;
        select.enabled = false;
    }
}

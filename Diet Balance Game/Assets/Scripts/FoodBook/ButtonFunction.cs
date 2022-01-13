using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonFunction : MonoBehaviour
{
    public Score score;

    public void OnClickRight()
    {

    }

    public void OnClickLeft()
    {

    }

    public void OnClickBack()
    {
        score.foodbookFlag = false;
    }
}

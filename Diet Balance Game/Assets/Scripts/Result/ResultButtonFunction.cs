using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultButtonFunction : MonoBehaviour
{
    public Result result;

    public void OnclickResultButton()
    {
        result.resultButtonFlag = true;
    }
}

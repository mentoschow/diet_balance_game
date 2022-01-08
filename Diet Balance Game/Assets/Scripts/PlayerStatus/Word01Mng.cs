using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Word01Mng : MonoBehaviour
{
    public PlayerManager pm;
    public RectTransform word1;

    int status;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        status = pm.hero.statusid;      //プレイヤーのステータスID
        if (status == 0 || status == 1 || status == 3)
        {
            word1.position = new Vector3(620, 170, 0);
        }
        else
        {
            word1.position = new Vector3(550, 150, 0);
        }
    }
}

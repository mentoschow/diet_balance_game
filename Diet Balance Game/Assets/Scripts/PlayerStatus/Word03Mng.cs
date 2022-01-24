using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Word03Mng : MonoBehaviour
{
    public PlayerManager pm;
    public RectTransform word3;

    int status;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        status = pm.hero.statusid;      //プレイヤーのステータスID
        
        if(status == 2 || status == 4)
        {
            word3.position = new Vector3(850, 170, 0);
        }
    }
}

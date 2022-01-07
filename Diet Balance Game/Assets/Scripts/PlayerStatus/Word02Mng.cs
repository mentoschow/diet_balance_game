using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Word02Mng : MonoBehaviour
{
    public PlayerManager pm;
    public RectTransform word2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int status = pm.hero.statusid;      //プレイヤーのステータスID

        if (status == 0 || status == 1 || status == 3)
        {
            word2.position = new Vector3(800, 170, 0);
        }
        else
        {
            word2.position = new Vector3(700, 170, 0);
        }
    }
}

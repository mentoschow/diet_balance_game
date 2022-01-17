using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Word03Mng : MonoBehaviour
{
    public PlayerManager pm;
    public RectTransform word3;

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
            this.gameObject.SetActive(false);
            //word3.position = new Vector3(800, 150, 0);
        }
        else
        {
            this.gameObject.SetActive(true);
            word3.position = new Vector3(850, 170, 0);
        }
    }
}

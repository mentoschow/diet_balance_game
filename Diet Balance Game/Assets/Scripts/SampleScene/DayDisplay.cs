using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayDisplay : MonoBehaviour
{
    public bool next = false;

    public PlayerManager pm;
    public Result result;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(result.next && this.enabled)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("DayDisplay");
                pm.hero.statusid = Random.Range(0, 5);  //プレイヤーのステータスの変更
                pm.hero.day++;                          //日数を進める
                next = true;
            }

        }
    }
}

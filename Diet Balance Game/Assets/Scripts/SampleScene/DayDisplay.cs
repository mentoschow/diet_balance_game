using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayDisplay : MonoBehaviour
{
    public bool next = false;
    bool animationFlag = true;

    public PlayerManager pm;
    public BattleManager bm;
    public Result result;

    [SerializeField] Animator Animation = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if((result.next || bm.goawayNext) && this.enabled)
        {
            if (animationFlag)
            {
                //animation on
                Animation.SetTrigger("MoveTrigger");
                animationFlag = false;
            }
            

            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("DayDisplay");
                pm.hero.statusid = Random.Range(0, 5);  //プレイヤーのステータスの変更
                Animation.SetTrigger("StateTrigger");   //animation off
                next = true;
                animationFlag = true;
            }

        }
    }
}

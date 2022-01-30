using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleButtonFunction : MonoBehaviour
{
    public BattleManager bm;
    public PlayerManager pm;

    public void OnClickBattle()
    {
        bm.battle_button_flag = true;
    }

    public void OnClickGoAway()
    {
        if(pm.hero.healthy > 29)
        {
            bm.goaway_button_flag = true;
        }
    }
}

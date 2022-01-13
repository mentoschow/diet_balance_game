using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleButtonFunction : MonoBehaviour
{
    public BattleManager bm;

    public void OnClickBattle()
    {
        bm.battle_button_flag = true;
    }

    public void OnClickGoAway()
    {
        bm.goaway_button_flag = true;
    }
}

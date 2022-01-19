using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Result : MonoBehaviour
{
    public bool next = false;

    public Canvas gameover;

    public PlayerManager pm;
    public BattleManager bm;
    public AssetConfig result_text;
    public AssetConfig DayNumImg;

    [SerializeField] Image ResultText = null;      //プレイヤー画像
    [SerializeField] Image DayText = null;        //日達成，日終了のテキスト
    [SerializeField] Image Day01 = null;        //日にちの一の位
    [SerializeField] Image Day02 = null;        //日にちの十の位

    // Start is called before the first frame update
    void Start()
    {
        pm.hero.day = 1;
        gameover.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        int day = pm.hero.day;
        int status = pm.hero.statusid;
        int day1;
        int day2;


        //日数の表示
        if (day < 10)
        {
            Day01.sprite = DayNumImg.sprites[day];
            Day02.gameObject.SetActive(false);
        }
        else
        {
            day1 = day % 10;
            day2 = day / 10;
            Day02.gameObject.SetActive(true);
            Day01.sprite = DayNumImg.sprites[day1];
            Day02.sprite = DayNumImg.sprites[day2];
        }

        //勝ち負けによって，表示を変える
        if (bm.battle_result == true)
        {
            ResultText.sprite = result_text.sprites[0];
            DayText.sprite = result_text.sprites[2];

            if (bm.next)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    next = true;
                }
            }
        }
        else
        {
            ResultText.sprite = result_text.sprites[1];
            DayText.sprite = result_text.sprites[3];

            if (bm.next)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    this.enabled = false;
                    gameover.enabled = true;
                }
            }
        }
        
    }
}

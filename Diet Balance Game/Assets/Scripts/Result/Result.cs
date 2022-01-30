using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Result : MonoBehaviour
{
    public bool next = false;
    public bool run_animation = false;
    public bool gameoverFlag;

    public Canvas gameover;

    public PlayerManager pm;
    public BattleManager bm;
    public ResultPP r_pp;
    public Score score;
    public AssetConfig resultBack;
    public AssetConfig resultChara;
    public AssetConfig result_text;
    public AssetConfig DayNumImg;

    [SerializeField] Image background = null;
    [SerializeField] Image character = null;
    [SerializeField] Image ResultText = null;      //プレイヤー画像
    [SerializeField] Image DayText = null;        //日達成，日終了のテキスト
    [SerializeField] Image Day01 = null;        //日にちの一の位
    [SerializeField] Image Day02 = null;        //日にちの十の位

    [SerializeField] Text ResultTextSentence = null;

    //Flags of function
    bool dayflag = true;
    bool imageflag = true;

    // Start is called before the first frame update
    void Start()
    {
        pm.hero.day = 1;
        gameover.enabled = false;
        gameoverFlag = false;
    }

    // Update is called once per frame
    void Update()
    {
        int status = pm.hero.statusid;

        if (bm.next && bm.goawayNext == false && gameoverFlag == false)
        {
            run_animation = true;

            //Set Day Image
            if (dayflag)
            {
                DayDisplay();
            }

            //Set some images
            if (imageflag)
            {
                transform_nutParam_to_pentagonParam();  //parameta using making pentagon
                ImageDisplay();
            }

            //Change processing by battle result
            if (bm.battle_result == true)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    next = true;
                    Initialize();
                }
            }
            else
            {
               if (Input.GetMouseButtonDown(0))
               {
                   RankDataChange();
                   Initialize();
                   gameover.enabled = true;
                   gameoverFlag = true;
               }
            }
        }  
    }

    void DayDisplay()
    {
        int day = pm.hero.day;
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

        dayflag = false;
    }

    void ImageDisplay()
    {
        //勝ち負けによって，表示を変える
        if (bm.battle_result == true)
        {
            background.sprite = resultBack.sprites[0];
            if (pm.isboy)
            {
                character.sprite = resultChara.sprites[0];  //boy
            }
            else
            {
                character.sprite = resultChara.sprites[1];  //girl
            }
            ResultText.sprite = result_text.sprites[0];
            DayText.sprite = result_text.sprites[2];
            WinText();
        }
        else
        {
            background.sprite = resultBack.sprites[1];
            character.sprite = resultChara.sprites[2];      //mother
            ResultText.sprite = result_text.sprites[1];
            DayText.sprite = result_text.sprites[3];
            LoseText();
        }

        imageflag = false;
    }


    void transform_nutParam_to_pentagonParam()
    {
        float range_max = 1.5f;
        float max_param = 1.7f;

        //sum player's three selection
        float carb_p, lipid_p, protein_p, vitamin_p, mineral_p;
        carb_p = pm.selectedFoodData1.carb + pm.selectedFoodData2.carb + pm.selectedFoodData3.carb;
        lipid_p = pm.selectedFoodData1.lipid + pm.selectedFoodData2.lipid + pm.selectedFoodData3.lipid;
        protein_p = pm.selectedFoodData1.protein + pm.selectedFoodData2.protein + pm.selectedFoodData3.protein;
        vitamin_p = pm.selectedFoodData1.vitamin + pm.selectedFoodData2.vitamin + pm.selectedFoodData3.vitamin;
        mineral_p = pm.selectedFoodData1.mineral + pm.selectedFoodData2.mineral + pm.selectedFoodData3.mineral;

        r_pp.vitamin_max = range_max * vitamin_p / pm.baseNut.vitamin;
        r_pp.carb_max = range_max * carb_p / pm.baseNut.carb;
        r_pp.lipid_max = range_max * lipid_p / pm.baseNut.lipid;
        r_pp.protein_max = range_max * protein_p / pm.baseNut.protein;
        r_pp.mineral_max = range_max * mineral_p / pm.baseNut.mineral;

        //if each nutrition is larger than range_max, that is changed to max_param
        if (r_pp.vitamin_max > range_max)
        {
            r_pp.vitamin_max = max_param;
        }
        if (r_pp.carb_max > range_max)
        {
            r_pp.carb_max = max_param;
        }
        if (r_pp.lipid_max > range_max)
        {
            r_pp.lipid_max = max_param;
        }
        if (r_pp.protein_max > range_max)
        {
            r_pp.protein_max = max_param;
        }
        if (r_pp.mineral_max > range_max)
        {
            r_pp.mineral_max = max_param;
        }
    }


    void Initialize()
    {
        dayflag = true;
        imageflag = true;
        run_animation = false;
        r_pp.Initialized_RPP();
    }



    //Text
    void WinText()
    {
        string[] text = new string[5];
        text[0] = "バランス良く栄養が摂れてるね！この調子で健康な食生活を続けていこう！";
        text[1] = "ビタミンとミネラルをしっかり摂って、風邪の対策ができたみたい。この調子で健康な食生活を続けていこう！";   //cold
        text[2] = "忙しいけど、エネルギーになるタンパク質を摂って元気にがんばれそう！この調子で健康な食生活を続けていこう！"; //busy
        text[3] = "脂質や炭水化物を抑えたことで、太り過ぎを抑えられたみたい！この調子で健康な食生活を続けていこう！";
        text[4] = "ビタミンをしっかり摂ったから、肌荒れ対策ができたみたい！この調子で健康な食生活を続けていこう！";

        ResultTextSentence.text = text[pm.hero.statusid];
    }

    void LoseText()
    {
        string[] text = new string[5];
        text[0] = "栄養バランスが悪いみたい…。まずは、タンパク質・脂質・炭水化物・ビタミン・ミネラルの5つをバランス良く摂ることを意識しよう！タンパク質・脂質は肉、炭水化物は麺やご飯、ビタミン・ミネラルは野菜などに多く含まれるよ！";
        text[1] = "風邪を治すには、ビタミンやミネラルを多く採って免疫力をあげよう！";
        text[2] = "忙しいときは、エネルギーになるタンパク質やミネラルを多く摂るようにしよう！";
        text[3] = "脂質やタンパク質を摂りすぎると太ってしまうよ！ビタミンやミネラルもしっかり摂ろう。";
        text[4] = "肌の健康のためには、野菜や果物のビタミンをしっかり摂ろう！体を作るタンパク質となる肉も忘れずに。";

        ResultTextSentence.text = text[pm.hero.statusid];
    }


    //Ranking
    static void csvSave(int[] data, int repeatMax)
    {

        string filepath = Application.dataPath + "/Resources/CSV/rankData.csv";
        string[] StringRankArray = new string[3];
        for (int i = 0; i < repeatMax; i++)
        {
            StringRankArray[i] = data[i].ToString();
        }
        File.WriteAllLines(filepath, StringRankArray);

    }

    void RankDataChange()
    {
        int nowDay = pm.hero.day;
        int[] rank = new int[3];
        //int[] newrank = new int[3];
        int point = 9;
        int defaultRank = 3;

        for (int i = 0; i < defaultRank; i++)
        {
            rank[i] = score.PlayerRank.rank[i];

            if (nowDay > rank[i])
            {
                point = i;
                score.PlayerRank.rank[i] = nowDay;
                break;
            }
            else
            {
                score.PlayerRank.rank[i] = rank[i];
            }
        }

        
        for (int i = point; i < defaultRank - 1; i++)
        {
            score.PlayerRank.rank[i + 1] = rank[i];
        }
        

        csvSave(score.PlayerRank.rank, defaultRank);
    }
}

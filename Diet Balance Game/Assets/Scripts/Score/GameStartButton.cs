using System.Collections;
using System.Collections.Generic;
using System.IO;        //csvReader用
using UnityEngine;

public class GameStartButton : MonoBehaviour
{
    public Score score;
    public PlayerManager pm;

    static TextAsset csvFile;   //csvファイルを変数として扱う
    static List<string[]> baseData = new List<string[]>();     //csvファイルから読み込んだ情報を格納する配列

    //csvファイル読み込み関数
    static void csvReader()
    {
        csvFile = Resources.Load("CSV/baseNut") as TextAsset;
        StringReader reader = new StringReader(csvFile.text);
        //csvの最終行まで読み込む
        while (reader.Peek() != -1)
        {
            string line = reader.ReadLine();    //一行ずつ読み込む
            baseData.Add(line.Split(','));     //コンマ区切りでListに格納
        }
    }

    //StartButton
    public void OnClickStartButton()
    {
        score.next = true;
        //年齢と性別から栄養素のベースデータを読み込み
        int id = 0;
        int player_age = 0;

        player_age = int.Parse(pm.hero.age);
        if (pm.isboy)
        {
            if (player_age < 30)
            {
                id = 1;
            }
            else if (player_age < 50)
            {
                id = 2;
            }
            else
            {
                id = 3;
            }
        }
        else
        {
            if (player_age < 30)
            {
                id = 4;
            }
            else if (player_age < 50)
            {
                id = 5;
            }
            else
            {
                id = 6;
            }
        }

        csvReader();
        pm.baseNut.energy = int.Parse(baseData[id][2]);
        pm.baseNut.carb = float.Parse(baseData[id][3]);
        pm.baseNut.lipid = float.Parse(baseData[id][4]);
        pm.baseNut.protein = float.Parse(baseData[id][5]);
        pm.baseNut.vitamin = float.Parse(baseData[id][6]);
        pm.baseNut.mineral = float.Parse(baseData[id][7]);

        pm.hero.healthy = 50;
    }
}

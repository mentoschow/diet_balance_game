using System.Collections;
using System.Collections.Generic;
using System.IO;        //csvReader�p
using UnityEngine;

public class GameStartButton : MonoBehaviour
{
    public Score score;
    public PlayerManager pm;

    static TextAsset csvFile;   //csv�t�@�C����ϐ��Ƃ��Ĉ���
    static List<string[]> baseData = new List<string[]>();     //csv�t�@�C������ǂݍ��񂾏����i�[����z��

    //csv�t�@�C���ǂݍ��݊֐�
    static void csvReader()
    {
        csvFile = Resources.Load("CSV/baseNut") as TextAsset;
        StringReader reader = new StringReader(csvFile.text);
        //csv�̍ŏI�s�܂œǂݍ���
        while (reader.Peek() != -1)
        {
            string line = reader.ReadLine();    //��s���ǂݍ���
            baseData.Add(line.Split(','));     //�R���}��؂��List�Ɋi�[
        }
    }

    //StartButton
    public void OnClickStartButton()
    {
        score.next = true;
        //�N��Ɛ��ʂ���h�{�f�̃x�[�X�f�[�^��ǂݍ���
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

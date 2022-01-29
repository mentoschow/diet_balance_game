using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;    //UIの追加

public class Score : MonoBehaviour
{
    public bool next = false;
    public bool foodbookFlag = false;
    bool rankDataFlag = true;

    public PlayerManager pm;
    public Performance p;
    public AssetConfig character;
    public AssetConfig ScoreNumImg;

    [SerializeField] Image Rank1_1;
    [SerializeField] Image Rank1_2;
    [SerializeField] Image Rank2_1;
    [SerializeField] Image Rank2_2;
    [SerializeField] Image Rank3_1;
    [SerializeField] Image Rank3_2;

    [SerializeField] Image PlayerImg = null;      //プレイヤー画像

    //ランキングの情報保存用変数
    static List<string[]> rankData = new List<string[]>();     //csvファイルから読み込んだ情報を格納する配列
    static TextAsset csvFile;   //csvファイルを変数として扱う

    //csvファイル読み込み関数
    static void csvReader()
    {
        csvFile = Resources.Load("CSV/rankData") as TextAsset;
        StringReader reader = new StringReader(csvFile.text);
        //csvの最終行まで読み込む
        while (reader.Peek() != -1)
        {
            string line = reader.ReadLine();    //一行ずつ読み込む
            rankData.Add(line.Split(','));     //コンマ区切りでListに格納
        }
    }

    [System.Serializable]
    public struct RankStruct
    {
        public int[] rank;
        //public int rank1;
        //public int rank2;
        //public int rank3;

    }
    public RankStruct PlayerRank;

    // Start is called before the first frame update
    void Start()
    {
        rankDataFlag = true;
        Rank1_2.gameObject.SetActive(false);
        Rank2_2.gameObject.SetActive(false);
        Rank3_2.gameObject.SetActive(false);

        //load rank data
        csvReader();
        PlayerRank.rank = new int[3];
        for (int i = 0; i < 3; i++)
        {
            PlayerRank.rank[i] = int.Parse(rankData[i][0]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //プレイヤー画像の表示
        if (pm.isboy == true)
        {
            PlayerImg.sprite = character.sprites[0];
        }
        else
        {
            PlayerImg.sprite = character.sprites[1];
        }

        if (p.next && next == false && rankDataFlag)
        {
            RankData();
        }
    }

    void RankData()
    {
        int[] rankOne = new int[3];
        int[] rankTen = new int[3];

        csvReader();

        for (int i = 0; i < 3; i++)
        {
            if(PlayerRank.rank[i] < 10)
            {
                rankOne[i] = PlayerRank.rank[i];
                rankTen[i] = 0;
            }
            else
            {
                rankOne[i] = PlayerRank.rank[i] % 10;
                rankTen[i] = PlayerRank.rank[i] / 10;
            }
        }

        Rank1_1.sprite = ScoreNumImg.sprites[rankOne[0]];
        Rank2_1.sprite = ScoreNumImg.sprites[rankOne[1]];
        Rank3_1.sprite = ScoreNumImg.sprites[rankOne[2]];

        if (rankTen[0] > 0)
        {
            Rank1_2.gameObject.SetActive(true);
            Rank1_2.sprite = ScoreNumImg.sprites[rankTen[0]];
        }
        if (rankTen[1] > 0)
        {
            Rank2_2.gameObject.SetActive(true);
            Rank2_2.sprite = ScoreNumImg.sprites[rankTen[1]];
        }
        if (rankTen[2] > 0)
        {
            Rank3_2.gameObject.SetActive(true);
            Rank3_2.sprite = ScoreNumImg.sprites[rankTen[2]];
        }

        rankDataFlag = false;
    }

    public void Initialized()
    {
        rankDataFlag = true;
    }
}

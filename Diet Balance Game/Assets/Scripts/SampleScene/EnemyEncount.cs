using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;    //UIの追加

public class EnemyEncount : MonoBehaviour
{
    public bool next;           //シーン遷移用のブール変数
    public PlayerManager pm;
    public FoodSelection fs;
    public AssetConfig enem;
    [SerializeField] Image EnemImg = null;      //敵画像

    static TextAsset csvFile;   //csvファイルを変数として扱う

    //敵の情報保存用変数
    static List<string[]> enemyData = new List<string[]>();     //csvファイルから読み込んだ情報を格納する配列
    public EnemyManager em;      //敵のパラメーター保存

    int normal_enem;    //normal用の敵乱数生成変数


    //csvファイル読み込み関数
    static void csvReader()
    {
        csvFile = Resources.Load("CSV/enemy_data") as TextAsset;
        StringReader reader = new StringReader(csvFile.text);
        //csvの最終行まで読み込む
        while (reader.Peek() != -1)
        {
            string line = reader.ReadLine();    //一行ずつ読み込む
            enemyData.Add(line.Split(','));     //コンマ区切りでListに格納
        }
    }

    void saveInfo(int enem_id)
    {
        em.enemy.enemID = int.Parse(enemyData[enem_id][0]);
        em.enemy.name = enemyData[enem_id][1];
        em.enemy.enemImgAddress = enemyData[enem_id][2];
        em.enemy.energy = int.Parse(enemyData[enem_id][3]);
        em.enemy.carb = float.Parse(enemyData[enem_id][4]);
        em.enemy.lipid = float.Parse(enemyData[enem_id][5]);
        em.enemy.protein = float.Parse(enemyData[enem_id][6]);
        em.enemy.vitamin = float.Parse(enemyData[enem_id][7]);
        em.enemy.mineral = float.Parse(enemyData[enem_id][8]);
    }

    // Start is called before the first frame update
    void Start()
    {
        //csvファイル読み込み
        csvReader();

        int enem_id = pm.hero.statusid;
        //IDから敵の情報読み込み
        int enemyID = int.Parse(enemyData[enem_id][0]);
        string name = enemyData[enem_id][1];
        string address = enemyData[enem_id][2];
        int energy = int.Parse(enemyData[enem_id][3]);
        float carb = float.Parse(enemyData[enem_id][4]);
        float lipid = float.Parse(enemyData[enem_id][5]);
        float protein = float.Parse(enemyData[enem_id][6]);
        float vitamin = float.Parse(enemyData[enem_id][7]);
        float mineral = float.Parse(enemyData[enem_id][8]);
        //構造体への保存
        //saveInfo(enem_id);d

        //normal用の敵乱数生成
        normal_enem = Random.Range(1, 4);
    }

    // Update is called once per frame
    void Update()
    {
        int status = pm.hero.statusid;
        //敵画像の表示
        if (status == 0)
        {
            //normalの敵がいないため，ランダム選択
            EnemImg.sprite = enem.sprites[normal_enem];
        }
        else
        {
            EnemImg.sprite = enem.sprites[status];
        }

        if (fs.next)
        {
            if (Input.GetMouseButtonDown(0))
            {
                next = true;
            }
        }
    }
}

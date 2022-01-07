using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;    //UIの追加

public class PlayerStatus : MonoBehaviour
{
    public bool next;           //シーン遷移用のブール変数
    public PlayerManager pm;
    public Performance p;
    public AssetConfig character;
    public AssetConfig popup;

    static TextAsset csvFile;   //csvファイルを変数として扱う
    [SerializeField] Image PlayerImg = null;      //Image UIの追加
    [SerializeField] Image PopImg = null;      //Image UIの追加

    //敵の情報保存用変数
    static List<string[]> enemyData = new List<string[]>();     //csvファイルから読み込んだ情報を格納する配列
    public EnemyManager em;      //敵のパラメーター保存

    //csvファイル読み込み関数
    static void csvReader()
    {
        csvFile = Resources.Load("CSV/enemy_data") as TextAsset;
        StringReader reader = new StringReader(csvFile.text);
        //csvの最終行まで読み込む
        while(reader.Peek() != -1)
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

        Random.InitState(System.DateTime.Now.Millisecond);  //時間による乱数初期化
        
        pm.hero.statusid = Random.Range(0, 4);
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
        //saveInfo(enem_id);
        //敵画像の表示
        //PlayerImg.sprite = Resources.Load<Sprite>(address);

        
        

    }

    // Update is called once per frame
    void Update()
    {
        int status = pm.hero.statusid;      //プレイヤーのステータスID
        
        //プレイヤー画像の表示
        if (pm.isboy == true)
        {
            PlayerImg.sprite = character.sprites[status * 2];
        }
        else
        {
            PlayerImg.sprite = character.sprites[status + (status * 2)];
        }

        //Pop画像の表示
        PopImg.sprite = popup.sprites[status];

        if (p.next)
        {
            if(Input.GetMouseButtonDown(0))
            {
                next = true;
            }
        }
        
    }
}

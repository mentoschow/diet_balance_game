using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;    //UIの追加

public class EnemyEncount : MonoBehaviour
{
    public bool next;           //シーン遷移用のブール変数
    public bool run_update;     //アニメーション関連のフラグ

    public PlayerManager pm;
    public FoodSelection fs;
    public AssetConfig enem;
    [SerializeField] Image EnemImg = null;      //敵画像

    static TextAsset csvFile;   //csvファイルを変数として扱う

    //敵の情報保存用変数
    static List<string[]> enemyData = new List<string[]>();     //csvファイルから読み込んだ情報を格納する配列
    public EnemyManager em;      //敵のパラメーター保存

    int normal_enem;    //normal用の敵乱数生成変数

    //ボタンの情報取得用
    GameObject childButton;
    Button NextButton;
    Animator ButtonAnime;

    public EnemImgMng EIM;
    public StatusParameter01 SP01;
    public StatusParameter02 SP02;
    public StatusParameter03 SP03;


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

    //敵情報をEnemyManagerの構造体へ保存
    void saveInfo(int enem_id)
    {
        em.enemy.enemID = enem_id;     
        em.enemy.energy = int.Parse(enemyData[enem_id][1]);
        em.enemy.carb = float.Parse(enemyData[enem_id][2]);
        em.enemy.lipid = float.Parse(enemyData[enem_id][3]);
        em.enemy.protein = float.Parse(enemyData[enem_id][4]);
        em.enemy.vitamin = float.Parse(enemyData[enem_id][5]);
        em.enemy.mineral = float.Parse(enemyData[enem_id][6]);
    }

    // Start is called before the first frame update
    void Start()
    {
        run_update = false;

        childButton = transform.Find("NextButton").gameObject;
        NextButton = childButton.gameObject.GetComponent<Button>();
        ButtonAnime = childButton.gameObject.GetComponent<Animator>();
        childButton.SetActive(false);

        //normal用の敵乱数生成
        normal_enem = Random.Range(1, 5);
        //csvファイル読み込み
        csvReader();
    }

    // Update is called once per frame
    void Update()
    {
        int status = pm.hero.statusid;
        
        int enem_id = normal_enem;
        if (status != 0)
        {
            enem_id = pm.hero.statusid;
        }
        //構造体へ敵情報の保存
        saveInfo(enem_id);

        //アニメーション動作開始
        if (fs.next && next == false)
        {
            run_update = true;
        }

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

        //ボタンの表示
        if (fs.next && SP03.end_flag == true)
        {
            childButton.SetActive(true);
            if (Input.GetMouseButtonDown(0))
            {
                next = true;
                Initilized_EEParam();
            }
        }
    }

    void Initilized_EEParam()
    {
        run_update = false;

        childButton.SetActive(false);
        EIM.Initilized_EnemImgMng();
        SP01.InitializedSP01();
        SP02.InitializedSP02();
        SP03.InitializedSP03();

        Debug.Log("EE Initilized");
    }
}

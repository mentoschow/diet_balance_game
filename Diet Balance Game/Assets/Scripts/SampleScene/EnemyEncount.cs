using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;    //UIの追加

public class EnemyEncount : MonoBehaviour
{
    public bool next;           //シーン遷移用のブール変数
    public bool run_update;     //アニメーション関連のフラグ
    public bool pentagon_animeFlag;     //Flag(using animation)

    public PlayerManager pm;
    public PlayerStatus ps;
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

    //子オブジェクト
    public EnemImgMng EIM;
    public EnemyStatusPentagon ESP;

    //warning images
    [SerializeField] Image warningLD;
    [SerializeField] Image warningLT;
    [SerializeField] Image warningRD;
    [SerializeField] Image warningRT;
    float oparate_warning_time;

    //pentagon
    [SerializeField] Image Pentagon = null;
    [SerializeField] Image PentagonText = null;

    //Pentagon.enabled = false;
    //Pentagon.enabled = true;

    //"enemy encount" text image
    [SerializeField] Image callText;

    //Animation
    [SerializeField] Animator AnimationLT = null;
    [SerializeField] Animator AnimationRT = null;
    [SerializeField] Animator AnimationRD = null;
    [SerializeField] Animator AnimationLD = null;


    void transform_FoodParam_to_pentagonParam()
    {
        float range_max = 1.5f;

        ESP.vitamin_fstmax = range_max * em.enemy.vitamin / pm.baseNut.vitamin;
        ESP.carb_fstmax    = range_max * em.enemy.carb    / pm.baseNut.carb;
        ESP.lipid_fstmax   = range_max * em.enemy.lipid   / pm.baseNut.lipid;
        ESP.protein_fstmax = range_max * em.enemy.protein / pm.baseNut.protein;
        ESP.mineral_fstmax = range_max * em.enemy.mineral / pm.baseNut.mineral;

    }

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
        em.enemy.energy = int.Parse(enemyData[enem_id][1]) * (int)pm.baseNut.energy / 100;
        em.enemy.carb = float.Parse(enemyData[enem_id][2]) * pm.baseNut.carb / 100;
        em.enemy.lipid = float.Parse(enemyData[enem_id][3]) * pm.baseNut.lipid / 100;
        em.enemy.protein = float.Parse(enemyData[enem_id][4]) * pm.baseNut.protein / 100;
        em.enemy.vitamin = float.Parse(enemyData[enem_id][5]) * pm.baseNut.vitamin / 100;
        em.enemy.mineral = float.Parse(enemyData[enem_id][6]) * pm.baseNut.mineral / 100;
    }

    // Start is called before the first frame update
    void Start()
    {
        run_update = false;
        pentagon_animeFlag = false;
        oparate_warning_time = 0;

        childButton = transform.Find("NextButton").gameObject;
        NextButton = childButton.gameObject.GetComponent<Button>();
        ButtonAnime = childButton.gameObject.GetComponent<Animator>();

        //text image
        childButton.SetActive(false);
        callText.gameObject.SetActive(false);
        //pentagon
        Pentagon.gameObject.SetActive(false);
        PentagonText.gameObject.SetActive(false);

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

        if (ps.next && next == false)
        {
            SceneAnimation();
        }
    }

    void SceneAnimation()
    {
        bool childButtonTrigger = false;

        if (EIM.end_enem_down == false)                           //enemy down animation
        {
            transform_FoodParam_to_pentagonParam();
            run_update = true;
        }
        else if (EIM.end_enem_down && pentagon_animeFlag == false)                      //warning (yellow line) animation and display "Enemy Encount" text image
        {
            if(YellowWarningAnimation())
            {
                childButton.SetActive(true);
                childButtonTrigger = true;
            }

            if (childButtonTrigger && Input.GetMouseButtonDown(0))
            {
                pentagon_animeFlag = true;
                childButton.SetActive(false);
            }
        }
        else if (pentagon_animeFlag && ESP.end_flag == false)                //Display pentagon
        {
            Pentagon.gameObject.SetActive(true);
            PentagonText.gameObject.SetActive(true);
        }
        else                                        //Display "call text" text image
        {
            callText.gameObject.SetActive(true);
            if (Input.GetMouseButtonDown(0))
            {
                next = true;
                Initilized_EEParam();
            }
        }
    }

    bool YellowWarningAnimation()
    {
        bool EndYellowWarning = false;

        oparate_warning_time += Time.deltaTime;
        
        if (oparate_warning_time > 1.2)
        {
            EndYellowWarning = true;
        }
        else if (oparate_warning_time > 0.9)
        {
            //AnimationLD.SetTrigger("MoveTrigger");
        }
        else if (oparate_warning_time > 0.6)
        {
            //AnimationRD.SetTrigger("MoveTrigger");
        }
        else if (oparate_warning_time > 0.3)
        {
            //AnimationRT.SetTrigger("MoveTrigger");
        }
        else
        {
            AnimationLT.SetTrigger("MoveTrigger");
            AnimationRT.SetTrigger("MoveTrigger");
            AnimationRD.SetTrigger("MoveTrigger");
            AnimationLD.SetTrigger("MoveTrigger");
        } 

        return EndYellowWarning;
    }

    void Initilized_EEParam()
    {
        run_update = false;
        pentagon_animeFlag = false;
        oparate_warning_time = 0;

        //text image
        callText.gameObject.SetActive(false);
        //pentagon
        Pentagon.gameObject.SetActive(false);
        PentagonText.gameObject.SetActive(false);

        EIM.Initilized_EnemImgMng();
        ESP.InitializedESP();

        //yellow warning image
        AnimationLT.SetTrigger("WaitTrigger");
        AnimationLD.SetTrigger("WaitTrigger");
        AnimationRT.SetTrigger("WaitTrigger");
        AnimationRD.SetTrigger("WaitTrigger");


        Debug.Log("EE Initilized");
    }
}

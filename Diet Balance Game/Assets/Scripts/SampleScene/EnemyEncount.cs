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

    //子オブジェクト
    public EnemImgMng EIM;
    public StatusParameter01 SP01;
    public StatusParameter02 SP02;
    public StatusParameter03 SP03;

    //選択された栄養素のパラメータを五角形のパラメータに変換したものを保存する構造体
    //0:ビタミン，1:炭水化物，2:脂質，3：タンパク質，4:ミネラル
    public struct FoodParam
    {
        public float[] select01;
        public float[] select02;
        public float[] select03;
    }
    public FoodParam pentagonParam;


    void transform_FoodParam_to_pentagonParam()
    {
        //１回目の選択のパラメータ変換
        SP01.vitamin_fstmax = 1.5f * pm.selectedFoodData1.vitamin / pm.baseNut.vitamin;
        SP01.carb_fstmax = 1.5f * pm.selectedFoodData1.carb / pm.baseNut.carb;
        SP01.lipid_fstmax = 1.5f * pm.selectedFoodData1.lipid / pm.baseNut.lipid;
        SP01.protein_fstmax = 1.5f * pm.selectedFoodData1.protein / pm.baseNut.protein;
        SP01.mineral_fstmax = 1.5f * pm.selectedFoodData1.mineral / pm.baseNut.mineral;

        //２回目の選択のパラメータ変換
        SP02.vitamin_sndmax = SP01.vitamin_fstmax + 1.5f * pm.selectedFoodData2.vitamin / pm.baseNut.vitamin;
        SP02.carb_sndmax = SP01.carb_fstmax + 1.5f * pm.selectedFoodData2.carb / pm.baseNut.carb;
        SP02.lipid_sndmax = SP01.lipid_fstmax + 1.5f * pm.selectedFoodData2.lipid / pm.baseNut.lipid;
        SP02.protein_sndmax = SP01.protein_fstmax + 1.5f * pm.selectedFoodData2.protein / pm.baseNut.protein;
        SP02.mineral_sndmax = SP01.mineral_fstmax + 1.5f * pm.selectedFoodData2.mineral / pm.baseNut.mineral;

        //３回目の選択のパラメータ変換
        SP03.vitamin_trdmax = SP02.vitamin_sndmax + 1.5f * pm.selectedFoodData3.vitamin / pm.baseNut.vitamin;
        SP03.carb_trdmax = SP02.carb_sndmax + 1.5f * pm.selectedFoodData3.carb / pm.baseNut.carb;
        SP03.lipid_trdmax = SP02.lipid_sndmax + 1.5f * pm.selectedFoodData3.lipid / pm.baseNut.lipid;
        SP03.protein_trdmax = SP02.protein_sndmax + 1.5f * pm.selectedFoodData3.protein / pm.baseNut.protein;
        SP03.mineral_trdmax = SP02.mineral_sndmax + 1.5f * pm.selectedFoodData3.mineral / pm.baseNut.mineral;

        Debug.Log("(EnemyEncount)pm.baseNut.vitamin" + pm.baseNut.vitamin);
        Debug.Log("(EnemyEncount)pm.baseNut.carb" + pm.baseNut.carb);
        Debug.Log("(EnemyEncount)pm.baseNut.lipid" + pm.baseNut.lipid);
        Debug.Log("(EnemyEncount)pm.baseNut.protein" + pm.baseNut.protein);
        Debug.Log("(EnemyEncount)pm.baseNut.mineral" + pm.baseNut.mineral);
        Debug.Log("pm.selectedFoodData1.vitamin"+ pm.selectedFoodData1.vitamin);
        Debug.Log("pm.selectedFoodData1.carb" + pm.selectedFoodData1.carb);
        Debug.Log("pm.selectedFoodData1.lipid" + pm.selectedFoodData1.lipid);
        Debug.Log("pm.selectedFoodData1.protein" + pm.selectedFoodData1.protein);
        Debug.Log("pm.selectedFoodData1.mineral" + pm.selectedFoodData1.mineral);
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
            transform_FoodParam_to_pentagonParam();
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

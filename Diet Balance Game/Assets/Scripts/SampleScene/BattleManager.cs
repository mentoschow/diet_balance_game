using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{
    public bool next = false;
    public bool run_animation;

    public bool battle_result = false; //WIN:true, LOSE:false

    public bool battle_button_flag = false;
    public bool goaway_button_flag = false;

    public EnemyManager em;  //enemy data
    public PlayerManager pm;  //player data
    public FoodSelection fs;
    public BattlePP b_pp;
    public BattleEP b_ep;

    public AssetConfig enem;
    public AssetConfig character;
    public AssetConfig probtext;

    //child object1
    public Image hero;
    public Image enemy;
    GameObject enemyObj;
    [SerializeField] Image backgroundScene01;
    [SerializeField] Image backgroundWhite;

    //child object2
    [SerializeField] Image backgroundScene02;
    [SerializeField] Image backFire;
    public Image basePentagon;
    public Image pentagonText;
    public Button fightButton;
    public Button goawayButton;
    public Image Winrate1;
    public Image Winrate2;
    public Image percentText;
    GameObject paramPentagon;


    //Button Image
    Image fightButtonImg;
    Image goawayButtonImg;

    //Flag
    bool sceneFlag = true;
    bool setCharaFlag = true;
    bool sceneAnimeFlag = false;
    bool fireEffectFlag = false;

    //background
    float backimg01_alpha;
    float backimg02_alpha;
    float backfire_alpha;
    float alphaSpeed;

    //enemy position
    Vector3 startPos;
    Vector3 endPos;
    Vector3 present_pos;
    float speed = 300.0F;
    float distance_two;     //distance two point
    float time_counter = 0;

    //win rate
    int probability;

    [SerializeField] Animator BackImgAnimation = null;

    void Start()
    {
        run_animation = false;
        fireEffectFlag = false;

        //get GameObject
        enemyObj = transform.Find("BattleEnemy").gameObject;
        paramPentagon = transform.Find("BattlePlayerParam").gameObject;
        fightButtonImg = fightButton.GetComponent<Image>();
        goawayButtonImg = goawayButton.GetComponent<Image>();

        hero.gameObject.SetActive(true);
        enemy.gameObject.SetActive(true);

        basePentagon.gameObject.SetActive(false);
        paramPentagon.SetActive(false);
        pentagonText.gameObject.SetActive(false);
        fightButton.gameObject.SetActive(false);
        goawayButton.gameObject.SetActive(false);
        Winrate1.gameObject.SetActive(false);
        Winrate2.gameObject.SetActive(false);
        percentText.gameObject.SetActive(false);

        //Background alpha
        backimg01_alpha = 1.0f;
        backimg02_alpha = 0f;
        backfire_alpha = 0f;
        alphaSpeed = 0.001f;

        //enemy position
        startPos = new Vector3(990, 360, 0);
        endPos = new Vector3(310, 400, 0);
        present_pos = startPos;
        distance_two = Vector3.Distance(startPos, endPos);
    }

    void Update()
    {
        if (fs.next == true && next == false)
        {
           
            if(setCharaFlag)
            {
                LoadCharacter(pm.hero.statusid);
                LoadEnemy(em.enemy.enemID);
                setCharaFlag = false;
                transform_nutParam_to_pentagonParam();
            }

            if(sceneFlag)
            {
                BattleScene01();
            }
            else
            {
                if(sceneAnimeFlag)
                {
                    SceneAnimation();
                }
                else
                {
                    BattleScene02();
                }
                
            }   
        }
    }

    void BattleScene01()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //background(red and blue) is moved
            BackImgAnimation.SetTrigger("MoveTrigger");

            battle_result = Battle();
            sceneAnimeFlag = true;
            sceneFlag = false;

            //deactive
            hero.gameObject.SetActive(false);
        }
    }

    void BattleScene02()
    {
        float fireRand = 0;
        float buttonRand = 0;

        //Fire Animation and Button Animation
        if (fireEffectFlag)
        {
            fireRand = (float)Random.Range(70, 100) / 100f;
            buttonRand = (float)Random.Range(85, 100) / 100f;
            backFire.color = new Color(255f, 255f, 255f, fireRand);
            fightButtonImg.color = new Color(255f, 255f, 255f, buttonRand);
            goawayButtonImg.color = new Color(255f, 255f, 255f, buttonRand);
        }
        else if (backfire_alpha < 1.0f)
        {
            backfire_alpha += alphaSpeed;
            backFire.color = new Color(255f, 255f, 255f, backfire_alpha);
        }
        else
        {
            fireEffectFlag = true;
        }

        if (run_animation == false)
        {
            //Load Number Image
            SetWinRateImg(probability);
            
        }

        if (battle_button_flag)
        {
            next = true;
            Debug.Log("Battle" + battle_result);
            battle_button_flag = false;
            Initilized_BattleMng();
        }

        if (goaway_button_flag)
        {
            Initilized_BattleMng();
        }
    }

    void SceneAnimation()
    {
        time_counter += Time.deltaTime;
        // 現在の位置
        float present_Location = time_counter * speed / distance_two;

        // オブジェクトの移動
        enemyObj.transform.position = Vector3.Lerp(startPos, endPos, present_Location);
        present_pos = Vector3.Lerp(startPos, endPos, present_Location);

        if (backimg02_alpha < 1.0f)
        {
            backimg01_alpha -= alphaSpeed;
            backimg02_alpha += alphaSpeed;
            //set
            backgroundScene01.color = new Color(255f, 255f, 255f, backimg01_alpha);
            backgroundWhite.color = new Color(255f, 255f, 255f, backimg01_alpha);
            backgroundScene02.color = new Color(255f, 255f, 255f, backimg02_alpha);
        }
        else
        {
            //move Scene2
            run_animation = true;
            sceneAnimeFlag = false;
            //active(Scene2)
            basePentagon.gameObject.SetActive(true);
            pentagonText.gameObject.SetActive(true);
            paramPentagon.SetActive(true);
            fightButton.gameObject.SetActive(true);
            goawayButton.gameObject.SetActive(true);
        }
    }

    bool Battle()
    {
        bool bool_result = false;
        int random_prob = 0;

        //Calculating win rate
        probability = CalculateProb();
        random_prob = 0;//Random.Range(0, 100);

        //Battle result(Win or Lose)
        if (random_prob < probability)
        {
            bool_result = true; //win
        }
        else
        {
            bool_result = false;    //lose
        }

        Debug.Log(probability + ", " + random_prob);

        return bool_result;
    }

    void LoadCharacter(int status)
    {
        //プレイヤー画像の表示
        if (pm.isboy == true)
        {
            hero.sprite = character.sprites[status * 2];
        }
        else
        {
            hero.sprite = character.sprites[status * 2 + 1];
        }
    }

    void LoadEnemy(int status)
    {
        //Debug.Log("enemAddress: "+enemAddress);
        enemy.sprite = enem.sprites[status];
    }

    void SetWinRateImg(int winrate)
    {
        int text1, text2;

        Winrate1.gameObject.SetActive(true);
        percentText.gameObject.SetActive(true);

        if (winrate < 10)
        {
            text1 = winrate;
            Winrate1.sprite = probtext.sprites[text1];
            Winrate2.gameObject.SetActive(false);
        }
        else
        {
            text1 = winrate % 10;
            text2 = winrate / 10;
            Winrate2.gameObject.SetActive(true);
            Winrate1.sprite = probtext.sprites[text1];
            Winrate2.sprite = probtext.sprites[text2];
        }
    }


    //calculating a win rate
    int CalculateProb()
    {
        int result_prob;
        int win_count = 0;
        float energy_prob, carb_prob, lipid_prob, protein_prob, vitamin_prob, mineral_prob;
        float energy_p, carb_p, lipid_p, protein_p, vitamin_p, mineral_p;

        //sum player's three selection
        energy_p = pm.selectedFoodData1.energy + pm.selectedFoodData2.energy + pm.selectedFoodData3.energy;
        carb_p = pm.selectedFoodData1.carb + pm.selectedFoodData2.carb + pm.selectedFoodData3.carb;
        lipid_p = pm.selectedFoodData1.lipid + pm.selectedFoodData2.lipid + pm.selectedFoodData3.lipid;
        protein_p = pm.selectedFoodData1.protein + pm.selectedFoodData2.protein + pm.selectedFoodData3.protein;
        vitamin_p = pm.selectedFoodData1.vitamin + pm.selectedFoodData2.vitamin + pm.selectedFoodData3.vitamin;
        mineral_p = pm.selectedFoodData1.mineral + pm.selectedFoodData2.mineral + pm.selectedFoodData3.mineral;

        //calculate each probability
        energy_prob = (pm.baseNut.energy - Mathf.Abs(pm.baseNut.energy - energy_p)) / pm.baseNut.energy;
        carb_prob = (pm.baseNut.carb - Mathf.Abs(pm.baseNut.carb - carb_p)) / pm.baseNut.carb;
        lipid_prob = (pm.baseNut.lipid - Mathf.Abs(pm.baseNut.lipid - lipid_p)) / pm.baseNut.lipid;
        protein_prob = (pm.baseNut.protein - Mathf.Abs(pm.baseNut.protein - protein_p)) / pm.baseNut.protein;
        vitamin_prob = (pm.baseNut.vitamin - Mathf.Abs(pm.baseNut.vitamin - vitamin_p)) / pm.baseNut.vitamin;
        mineral_prob = (pm.baseNut.mineral - Mathf.Abs(pm.baseNut.mineral - mineral_p)) / pm.baseNut.mineral;

        Debug.Log("energy" + energy_p);
        Debug.Log("carb" + carb_p);
        Debug.Log("lipid" + lipid_p);
        Debug.Log("protein" + protein_p);
        Debug.Log("vitamin" + vitamin_p);
        Debug.Log("mineral" + mineral_p);

        //the number of player's parameter that player wins
        if (em.enemy.energy < energy_p)
        {
            win_count++;
        }
        if (em.enemy.carb < carb_p)
        {
            win_count++;
        }
        if (em.enemy.lipid < lipid_p)
        {
            win_count++;
        }
        if (em.enemy.protein < protein_p)
        {
            win_count++;
        }
        if (em.enemy.vitamin < vitamin_p)
        {
            win_count++;
        }
        if (em.enemy.mineral < mineral_p)
        {
            win_count++;
        }

        result_prob = (int)( (100 * (energy_prob + carb_prob + lipid_prob + protein_prob + vitamin_prob + mineral_prob) / 6) * win_count / 6 );

        //initialize
        win_count = 0;

        return result_prob;
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

        b_pp.vitamin_max = range_max * vitamin_p / pm.baseNut.vitamin;
        b_pp.carb_max = range_max * carb_p / pm.baseNut.carb;
        b_pp.lipid_max = range_max * lipid_p / pm.baseNut.lipid;
        b_pp.protein_max = range_max * protein_p / pm.baseNut.protein;
        b_pp.mineral_max = range_max * mineral_p / pm.baseNut.mineral;

        //if each nutrition is larger than range_max, that is changed to max_param
        if(b_pp.vitamin_max > range_max)
        {
            b_pp.vitamin_max = max_param;
        }
        if (b_pp.carb_max > range_max)
        {
            b_pp.carb_max = max_param;
        }
        if (b_pp.lipid_max > range_max)
        {
            b_pp.lipid_max = max_param;
        }
        if (b_pp.protein_max > range_max)
        {
            b_pp.protein_max = max_param;
        }
        if (b_pp.mineral_max > range_max)
        {
            b_pp.mineral_max = max_param;
        }

        b_ep.vitamin = range_max * em.enemy.vitamin / pm.baseNut.vitamin;
        b_ep.carb = range_max * em.enemy.carb / pm.baseNut.carb;
        b_ep.lipid = range_max * em.enemy.lipid / pm.baseNut.lipid;
        b_ep.protein = range_max * em.enemy.protein / pm.baseNut.protein;
        b_ep.mineral = range_max * em.enemy.mineral / pm.baseNut.mineral;
    }

        void Initilized_BattleMng()
    {
        run_animation = false;
        sceneFlag = true;
        setCharaFlag = true;
        sceneAnimeFlag = false;
        fireEffectFlag = false;

        backimg01_alpha = 1.0f;
        backimg02_alpha = 0f;
        backfire_alpha = 0f;

        backgroundScene01.color = new Color(255f, 255f, 255f, 1.0f);
        backgroundWhite.color = new Color(255f, 255f, 255f, 1.0f);
        backgroundScene02.color = new Color(255f, 255f, 255f, 0.0f);
        backFire.color = new Color(255f, 255f, 255f, 0.0f);

        basePentagon.gameObject.SetActive(false);
        paramPentagon.SetActive(false);
        pentagonText.gameObject.SetActive(false);
        fightButton.gameObject.SetActive(false);
        goawayButton.gameObject.SetActive(false);
        Winrate1.gameObject.SetActive(false);
        Winrate2.gameObject.SetActive(false);
        percentText.gameObject.SetActive(false);

        BackImgAnimation.SetTrigger("EmptyTrigger");

        b_pp.Initialized_BPP();
    }
}

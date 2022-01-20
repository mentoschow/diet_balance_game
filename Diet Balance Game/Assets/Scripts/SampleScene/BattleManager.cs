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

    public AssetConfig enem;
    public AssetConfig character;
    public AssetConfig probtext;

    //child object1
    public Image hero;
    public Image enemy;
    GameObject enemyObj;
    [SerializeField] Image backgroundScene01;

    //child object2
    [SerializeField] Image backgroundScene02;
    public Image basePentagon;
    public Button fightButton;
    public Button goawayButton;
    public Image Winrate1;
    public Image Winrate2;
    GameObject paramPentagon;

    //Flag
    bool sceneFlag = true;
    bool setCharaFlag = true;
    bool sceneAnimeFlag = false;

    //background
    float backimg01_alpha;
    float backimg02_alpha;
    float alphaSpeed;

    //enemy position
    Vector3 startPos;
    Vector3 endPos;
    Vector3 present_pos;
    float speed = 300.0F;
    float distance_two;     //distance two point
    float time_counter = 0;

    void Start()
    {
        run_animation = false;

        //get GameObject
        enemyObj = transform.Find("BattleEnemy").gameObject;
        paramPentagon = transform.Find("BattlePlayerParam").gameObject;

        hero.gameObject.SetActive(true);
        enemy.gameObject.SetActive(true);

        basePentagon.gameObject.SetActive(false);
        paramPentagon.SetActive(false);
        fightButton.gameObject.SetActive(false);
        goawayButton.gameObject.SetActive(false);

        //Background alpha
        backimg01_alpha = 1.0f;
        backimg02_alpha = 0f;
        alphaSpeed = 0.001f;

        //enemy position
        startPos = new Vector3(990, 360, 0);
        endPos = new Vector3(290, 360, 0);
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

            sceneAnimeFlag = true;
            sceneFlag = false;

            //deactive
            hero.gameObject.SetActive(false);
        }
    }

    void BattleScene02()
    {

        run_animation = true;

        if (battle_button_flag)
        {
            battle_result = Battle();
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
            backgroundScene02.color = new Color(255f, 255f, 255f, backimg02_alpha);
        }
        else
        {
            //move Scene2
            sceneAnimeFlag = false;
            //active(Scene2)
            basePentagon.gameObject.SetActive(true);
            paramPentagon.SetActive(true);
            fightButton.gameObject.SetActive(true);
            goawayButton.gameObject.SetActive(true);
        }
        
    }

    bool Battle()
    {
        bool bool_result = false;

        int probability;
        int random_prob = 0;

        //Calculating win rate
        probability = CalculateProb();
        random_prob = Random.Range(0, 100);

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

        //Load Number Image
        SetWinRateImg(probability);

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

        if(winrate < 10)
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

        //the number of player's parameter that player wins
        if(em.enemy.energy < energy_p)
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

    void Initilized_BattleMng()
    {
        run_animation = false;
        sceneFlag = true;
        setCharaFlag = true;
        sceneAnimeFlag = false;

        backimg01_alpha = 1.0f;
        backimg02_alpha = 0f;

        b_pp.Initialized_BPP();
    }
}

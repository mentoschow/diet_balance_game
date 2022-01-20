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
    float speed = 1.0F;
    float distance_two; //distance two point
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
        backimg01_alpha = 255f;
        backimg02_alpha = 0f;
        alphaSpeed = 0.001f;

        //enemy position
        startPos = new Vector3(350, 0, 0);
        endPos = new Vector3(-350, 0, 0);
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
                BattleScene02();
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
            //active(Scene2)
            basePentagon.gameObject.SetActive(true);
            fightButton.gameObject.SetActive(true);
            goawayButton.gameObject.SetActive(true);
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
        }

        if (goaway_button_flag)
        {
            
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

        if (alphaSpeed < 255f)
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
        }
        
    }

    bool Battle()
    {
        bool bool_result = false;

        int probability = 80;
        int random_prob = 0;

        //IDから敵の情報読み込み
        //int enemyID = enem_id;
        //string name = enemyData[enem_id][1];
        //string address = enemyData[enem_id][2];
        //int energy = int.Parse(enemyData[enem_id][3]);
        //float carb = float.Parse(enemyData[enem_id][4]);
        //float lipid = float.Parse(enemyData[enem_id][5]);
        //float protein = float.Parse(enemyData[enem_id][6]);
        //float vitamin = float.Parse(enemyData[enem_id][7]);
        //float mineral = float.Parse(enemyData[enem_id][8]);

        random_prob = Random.Range(0, 100);

        if (random_prob < probability)
        {
            bool_result = true;
            Initilized_BattleMng();
        }
        else
        {
            bool_result = false;
            Initilized_BattleMng();
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

    void Initilized_BattleMng()
    {
        run_animation = false;
        sceneFlag = true;
        setCharaFlag = true;
        sceneAnimeFlag = false;

        backimg01_alpha = 255f;
        backimg02_alpha = 0f;

        b_pp.Initialized_BPP();
    }
}

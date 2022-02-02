using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;    //UI�̒ǉ�

public class EnemyEncount : MonoBehaviour
{
    public bool next;           //�V�[���J�ڗp�̃u�[���ϐ�
    public bool run_update;     //�A�j���[�V�����֘A�̃t���O
    public bool pentagon_animeFlag;     //Flag(using animation)

    public PlayerManager pm;
    public PlayerStatus ps;
    public AssetConfig enem;
    [SerializeField] Image EnemImg = null;      //�G�摜

    static TextAsset csvFile;   //csv�t�@�C����ϐ��Ƃ��Ĉ���

    //�G�̏��ۑ��p�ϐ�
    static List<string[]> enemyData = new List<string[]>();     //csv�t�@�C������ǂݍ��񂾏����i�[����z��
    public EnemyManager em;      //�G�̃p�����[�^�[�ۑ�

    int normal_enem;    //normal�p�̓G���������ϐ�

    //�{�^���̏��擾�p
    GameObject childButton;
    Button NextButton;
    Animator ButtonAnime;

    //�q�I�u�W�F�N�g
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

    //csv�t�@�C���ǂݍ��݊֐�
    static void csvReader()
    {
        csvFile = Resources.Load("CSV/enemy_data") as TextAsset;
        StringReader reader = new StringReader(csvFile.text);
        //csv�̍ŏI�s�܂œǂݍ���
        while (reader.Peek() != -1)
        {
            string line = reader.ReadLine();    //��s���ǂݍ���
            enemyData.Add(line.Split(','));     //�R���}��؂��List�Ɋi�[
        }
    }

    //�G����EnemyManager�̍\���̂֕ۑ�
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

        //normal�p�̓G��������
        normal_enem = Random.Range(1, 5);
        //csv�t�@�C���ǂݍ���
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
        //�\���̂֓G���̕ۑ�
        saveInfo(enem_id);

        //�G�摜�̕\��
        if (status == 0)
        {
            //normal�̓G�����Ȃ����߁C�����_���I��
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

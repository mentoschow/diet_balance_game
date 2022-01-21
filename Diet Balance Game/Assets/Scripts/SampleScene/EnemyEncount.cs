using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;    //UI�̒ǉ�

public class EnemyEncount : MonoBehaviour
{
    public bool next;           //�V�[���J�ڗp�̃u�[���ϐ�
    public bool run_update;     //�A�j���[�V�����֘A�̃t���O

    public PlayerManager pm;
    public Score score;
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


    void transform_FoodParam_to_pentagonParam()
    {
        float range_max = 1.5f;

        ESP.vitamin_fstmax = range_max * em.enemy.vitamin / pm.baseNut.vitamin;
        ESP.carb_fstmax    = range_max * em.enemy.carb    / pm.baseNut.carb;
        ESP.lipid_fstmax   = range_max * em.enemy.lipid   / pm.baseNut.lipid;
        ESP.protein_fstmax = range_max * em.enemy.protein / pm.baseNut.protein;
        ESP.mineral_fstmax = range_max * em.enemy.mineral / pm.baseNut.mineral;

        //�P��ڂ̑I���̃p�����[�^�ϊ�
        //SP01.vitamin_fstmax = range_max * pm.selectedFoodData1.vitamin / pm.baseNut.vitamin;
        //SP01.carb_fstmax = range_max * pm.selectedFoodData1.carb       / pm.baseNut.carb;
        //SP01.lipid_fstmax = range_max * pm.selectedFoodData1.lipid     / pm.baseNut.lipid;
        //SP01.protein_fstmax = range_max * pm.selectedFoodData1.protein / pm.baseNut.protein;
        //SP01.mineral_fstmax = range_max * pm.selectedFoodData1.mineral / pm.baseNut.mineral;

        //�Q��ڂ̑I���̃p�����[�^�ϊ�
        //SP02.vitamin_sndmax = ESP.vitamin_fstmax + range_max * pm.selectedFoodData2.vitamin / pm.baseNut.vitamin;
        //SP02.carb_sndmax = ESP.carb_fstmax + range_max * pm.selectedFoodData2.carb / pm.baseNut.carb;
        //SP02.lipid_sndmax = ESP.lipid_fstmax + range_max * pm.selectedFoodData2.lipid / pm.baseNut.lipid;
        //SP02.protein_sndmax = ESP.protein_fstmax + range_max * pm.selectedFoodData2.protein / pm.baseNut.protein;
        //SP02.mineral_sndmax = ESP.mineral_fstmax + range_max * pm.selectedFoodData2.mineral / pm.baseNut.mineral;

        //�R��ڂ̑I���̃p�����[�^�ϊ�
        //SP03.vitamin_trdmax = SP02.vitamin_sndmax + range_max * pm.selectedFoodData3.vitamin / pm.baseNut.vitamin;
        //SP03.carb_trdmax = SP02.carb_sndmax + range_max * pm.selectedFoodData3.carb / pm.baseNut.carb;
        //SP03.lipid_trdmax = SP02.lipid_sndmax + range_max * pm.selectedFoodData3.lipid / pm.baseNut.lipid;
        //SP03.protein_trdmax = SP02.protein_sndmax + range_max * pm.selectedFoodData3.protein / pm.baseNut.protein;
        //SP03.mineral_trdmax = SP02.mineral_sndmax + range_max * pm.selectedFoodData3.mineral / pm.baseNut.mineral;

        //Debug.Log("(EnemyEncount)pm.baseNut.vitamin" + pm.baseNut.vitamin);
        //Debug.Log("(EnemyEncount)pm.baseNut.carb" + pm.baseNut.carb);
        //Debug.Log("(EnemyEncount)pm.baseNut.lipid" + pm.baseNut.lipid);
        //Debug.Log("(EnemyEncount)pm.baseNut.protein" + pm.baseNut.protein);
        //Debug.Log("(EnemyEncount)pm.baseNut.mineral" + pm.baseNut.mineral);
        //Debug.Log("pm.selectedFoodData1.vitamin"+ pm.selectedFoodData1.vitamin);
        //Debug.Log("pm.selectedFoodData1.carb" + pm.selectedFoodData1.carb);
        //Debug.Log("pm.selectedFoodData1.lipid" + pm.selectedFoodData1.lipid);
        //Debug.Log("pm.selectedFoodData1.protein" + pm.selectedFoodData1.protein);
        //Debug.Log("pm.selectedFoodData1.mineral" + pm.selectedFoodData1.mineral);
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

        //�A�j���[�V��������J�n
        if (score.next && next == false)
        {
            transform_FoodParam_to_pentagonParam();
            run_update = true;
        }

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

        //�{�^���̕\��
        if (ESP.end_flag == true)
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
        ESP.InitializedESP();

        Debug.Log("EE Initilized");
    }
}

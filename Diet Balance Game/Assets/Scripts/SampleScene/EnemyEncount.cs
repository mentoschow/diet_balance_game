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
    public FoodSelection fs;
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

    public EnemImgMng EIM;
    public StatusParameter01 SP01;
    public StatusParameter02 SP02;
    public StatusParameter03 SP03;


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
        if (fs.next && next == false)
        {
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

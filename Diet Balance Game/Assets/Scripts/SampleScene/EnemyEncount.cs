using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;    //UI�̒ǉ�

public class EnemyEncount : MonoBehaviour
{
    public bool next;           //�V�[���J�ڗp�̃u�[���ϐ�
    public PlayerManager pm;
    public FoodSelection fs;
    public AssetConfig enem;
    [SerializeField] Image EnemImg = null;      //�G�摜

    static TextAsset csvFile;   //csv�t�@�C����ϐ��Ƃ��Ĉ���

    //�G�̏��ۑ��p�ϐ�
    static List<string[]> enemyData = new List<string[]>();     //csv�t�@�C������ǂݍ��񂾏����i�[����z��
    public EnemyManager em;      //�G�̃p�����[�^�[�ۑ�

    int normal_enem;    //normal�p�̓G���������ϐ�


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
        //normal�p�̓G��������
        normal_enem = Random.Range(1, 5);
        Debug.Log(normal_enem);

        //csv�t�@�C���ǂݍ���
        csvReader();

        int enem_id = pm.hero.statusid;
        //ID����G�̏��ǂݍ���
        int enemyID = int.Parse(enemyData[enem_id][0]);
        string name = enemyData[enem_id][1];
        string address = enemyData[enem_id][2];
        int energy = int.Parse(enemyData[enem_id][3]);
        float carb = float.Parse(enemyData[enem_id][4]);
        float lipid = float.Parse(enemyData[enem_id][5]);
        float protein = float.Parse(enemyData[enem_id][6]);
        float vitamin = float.Parse(enemyData[enem_id][7]);
        float mineral = float.Parse(enemyData[enem_id][8]);
        //�\���̂ւ̕ۑ�
        //saveInfo(enem_id);d

        
    }

    // Update is called once per frame
    void Update()
    {
        int status = pm.hero.statusid;
        
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

        if (fs.next)
        {
            if (Input.GetMouseButtonDown(0))
            {
                next = true;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;    //UI�̒ǉ�

public class EnemyEncount : MonoBehaviour
{
    public bool next;           //�V�[���J�ڗp�̃u�[���ϐ�
    public Performance p;

    static TextAsset csvFile;   //csv�t�@�C����ϐ��Ƃ��Ĉ���
    [SerializeField] Image EnemImg = null;      //Image UI�̒ǉ�

    //�G�̏��ۑ��p�ϐ�
    static List<string[]> enemyData = new List<string[]>();     //csv�t�@�C������ǂݍ��񂾏����i�[����z��
    public EnemyManager em;      //�G�̃p�����[�^�[�ۑ�

    //csv�t�@�C���ǂݍ��݊֐�
    static void csvReader()
    {
        Debug.Log("CSV READER START");
        csvFile = Resources.Load("CSV/enemy_data") as TextAsset;
        StringReader reader = new StringReader(csvFile.text);
        //csv�̍ŏI�s�܂œǂݍ���
        while(reader.Peek() != -1)
        {
            string line = reader.ReadLine();    //��s���ǂݍ���
            enemyData.Add(line.Split(','));     //�R���}��؂��List�Ɋi�[
        }
    }

    

    //static int enem_id = 1;     //�L�����I���ɂ���ĕύX�H�܂��̓����_���H

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("EnemyEncount START");
        //csv�t�@�C���ǂݍ���
        csvReader();

        Random.InitState(System.DateTime.Now.Millisecond);  //���Ԃɂ�闐��������
        int enem_id = 1;//Random.Range(1, 5);

        Debug.Log("DATA FIND: " + enemyData[1][0]);
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
        //em.enemy.enemID = int.Parse(enemyData[enem_id][0]);
        //em.enemy.name = enemyData[enem_id][1];
        //em.enemy.enemImgAddress = enemyData[enem_id][2];
        //em.enemy.energy = int.Parse(enemyData[enem_id][3]);
        //em.enemy.carb = float.Parse(enemyData[enem_id][4]);
        //em.enemy.lipid = float.Parse(enemyData[enem_id][5]);
        //em.enemy.protein = float.Parse(enemyData[enem_id][6]);
        //em.enemy.vitamin = float.Parse(enemyData[enem_id][7]);
        //em.enemy.mineral = float.Parse(enemyData[enem_id][8]);

        //�G�摜�̕\��
        EnemImg.sprite = Resources.Load<Sprite>(address);

    }

    // Update is called once per frame
    void Update()
    {
        if (p.next)
        {
            if(Input.GetMouseButtonDown(0))
            {
                next = true;
            }
        }
        
    }
}

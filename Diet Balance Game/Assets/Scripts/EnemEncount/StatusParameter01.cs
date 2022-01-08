using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusParameter01 : DynamicPentagon
{
    public bool end_flag = false;
    public EnemImgMng EIM;

    float speed;

    float carb;
    float lipid;
    float protein;
    float vitamin;
    float mineral;

    float carb_fstmax;
    float lipid_fstmax;
    float protein_fstmax;
    float vitamin_fstmax;
    float mineral_fstmax;

    int flag_counter = 0;

    protected override void Awake()
    {
        base.Awake();
        SetUp();
    }

    protected override float getVertexRate(int index)
    {
        return m_ParameterList[index].value;
    }

    protected override int getVertexCount()
    {
        return m_ParameterList.Count;
    }

    [System.Serializable]
    public struct Parameter
    {
        public Parameter(string parameterName, float value)
        {
            this.parameterName = parameterName;
            this.value = value;
        }
        public string parameterName;

        [Range(0.0f, 1.0f)]
        public float value;
    }

    [SerializeField]
    public List<Parameter> m_ParameterList = new List<Parameter>();


    void Start()
    {
        carb = 0;
        lipid = 0;
        protein = 0;
        vitamin = 0;
        mineral = 0;

        m_ParameterList = new List<Parameter>
        {
            new Parameter( "�Y������", carb),
            new Parameter( "����", lipid),
            new Parameter( "�^���p�N��", protein),
            new Parameter( "�r�^�~��", vitamin),
            new Parameter( "�~�l����", mineral),
        };

        //1��ڂ̐H���œ����h�{�f(�Œ�l0�C�ő�l1�Ő��K��)
        carb_fstmax = 0.2f;
        lipid_fstmax = 0.5f;
        protein_fstmax = 0.4f;
        vitamin_fstmax = 0.5f;
        mineral_fstmax = 0.3f;
    }

    

    protected override void Update()
    {
        if (EIM.end_enem_down == true && end_flag == false)
        {
            speed += 0.001f;
            if (carb < carb_fstmax)
            {
                carb += speed;
            }
            else if(carb == carb_fstmax)
            {
                flag_counter++;
            }

            if(lipid < lipid_fstmax)
            {
                lipid += speed;
            }
            else if(lipid == lipid_fstmax)
            {
                flag_counter++;
            }

            if (protein < protein_fstmax)
            {
                protein += speed;
            }
            else if (protein == protein_fstmax)
            {
                flag_counter++;
            }

            if (vitamin < vitamin_fstmax)
            {
                vitamin += speed;
            }
            else if (vitamin == vitamin_fstmax)
            {
                flag_counter++;
            }

            if (mineral < mineral_fstmax)
            {
                mineral += speed;
            }
            else if (mineral == mineral_fstmax)
            {
                flag_counter++;
            }
            if(flag_counter == 5)
            {
                end_flag = true;
                Debug.Log("SP01 True");
            }
        }
        
        //�l�̍X�V
        m_ParameterList = new List<Parameter>
        {
            new Parameter( "�Y������", carb),
            new Parameter( "����", lipid),
            new Parameter( "�^���p�N��", protein),
            new Parameter( "�r�^�~��", vitamin),
            new Parameter( "�~�l����", mineral),
        };

        SetUp();
    }
}

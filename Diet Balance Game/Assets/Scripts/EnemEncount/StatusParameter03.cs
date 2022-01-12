using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusParameter03 : DynamicPentagon
{
    public bool end_flag = false;
    public EnemImgMng EIM;
    public StatusParameter02 SP02;

    float speed;

    float carb;
    float lipid;
    float protein;
    float vitamin;
    float mineral;

    float carb_trdmax;
    float lipid_trdmax;
    float protein_trdmax;
    float vitamin_trdmax;
    float mineral_trdmax;

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

        [Range(0.0f, 1.5f)]
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
            new Parameter( "�r�^�~��", vitamin),
            new Parameter( "�Y������", carb),
            new Parameter( "����", lipid),
            new Parameter( "�^���p�N��", protein),
            new Parameter( "�~�l����", mineral),
        };

        //1��ڂ̐H���œ����h�{�f(�Œ�l0�C�ő�l1�Ő��K��)
        carb_trdmax = 1.5f;
        lipid_trdmax = 1.5f;
        protein_trdmax = 1.5f;
        vitamin_trdmax = 1.5f;
        mineral_trdmax = 1.5f;
    }

    protected override void Update()
    {
        if (EIM.end_enem_down == true && end_flag == false && SP02.end_flag == true)
        {
            speed = Time.deltaTime;
            if (carb < carb_trdmax)
            {
                carb += speed;
            }
            else
            {
                flag_counter++;
            }

            if (lipid < lipid_trdmax)
            {
                lipid += speed;
            }
            else
            {
                flag_counter++;
            }
            if (protein < protein_trdmax)
            {
                protein += speed;
            }
            else
            {
                flag_counter++;
            }

            if (vitamin < vitamin_trdmax)
            {
                vitamin += speed;
            }
            else
            {
                flag_counter++;
            }

            if (mineral < mineral_trdmax)
            {
                mineral += speed;
            }
            else
            {
                flag_counter++;
            }

            //���̃p�����[�^�\���ɐi�ނ�
            if (flag_counter == 5)
            {
                end_flag = true;
            }
            else
            {
                flag_counter = 0;
            }
        }

        //�l�̍X�V
        m_ParameterList = new List<Parameter>
        {
            new Parameter( "�r�^�~��", vitamin),
            new Parameter( "�Y������", carb),
            new Parameter( "����", lipid),
            new Parameter( "�^���p�N��", protein),
            new Parameter( "�~�l����", mineral),
        };

        SetUp();
    }
}
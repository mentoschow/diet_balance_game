using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusParameter02 : DynamicPentagon
{
    public bool end_flag = false;
    public EnemImgMng EIM;
    public StatusParameter01 SP01;

    float speed;

    float carb;
    float lipid;
    float protein;
    float vitamin;
    float mineral;

    float carb_sndmax;
    float lipid_sndmax;
    float protein_sndmax;
    float vitamin_sndmax;
    float mineral_sndmax;

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
            new Parameter( "�Y������", carb),
            new Parameter( "����", lipid),
            new Parameter( "�^���p�N��", protein),
            new Parameter( "�r�^�~��", vitamin),
            new Parameter( "�~�l����", mineral),
        };

        //1��ڂ̐H���œ����h�{�f(�Œ�l0�C�ő�l1�Ő��K��)
        carb_sndmax = 1.1f;
        lipid_sndmax = 0.9f;
        protein_sndmax = 1.4f;
        vitamin_sndmax = 0.7f;
        mineral_sndmax = 1.3f;
    }

    float counter = 0;

    protected override void Update()
    {
        if (EIM.end_enem_down == true && end_flag == false && SP01.end_flag == true)
        {
            speed += 0.001f;
            if (carb < carb_sndmax)
            {
                carb += speed;
            }
            else
            {
                flag_counter++;
            }

            if (lipid < lipid_sndmax)
            {
                lipid += speed;
            }
            else
            {
                flag_counter++;
            }
            if (protein < protein_sndmax)
            {
                protein += speed;
            }
            else
            {
                flag_counter++;
            }

            if (vitamin < vitamin_sndmax)
            {
                vitamin += speed;
            }
            else
            {
                flag_counter++;
            }

            if (mineral < mineral_sndmax)
            {
                mineral += speed;
            }
            else
            {
                flag_counter++;
            }

            if (flag_counter == 5)
            {
                end_flag = true;
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

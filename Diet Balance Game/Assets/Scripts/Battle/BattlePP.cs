using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattlePP : DynamicPentagon
{
    public EnemyEncount ee;
    public BattleManager bm;
    float speed;

    float carb;
    float lipid;
    float protein;
    float vitamin;
    float mineral;

    float carb_max;
    float lipid_max;
    float protein_max;
    float vitamin_max;
    float mineral_max;

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

        //�H���œ����h�{�f�̍��v(�Œ�l0�C�ő�l1�Ő��K��)
        carb_max = 1.5f;
        lipid_max = 1.5f;
        protein_max = 1.5f;
        vitamin_max = 1.5f;
        mineral_max = 1.5f;
    }

    protected override void Update()
    {
        if (ee.next && bm.run_animation)
        {
            speed = Time.deltaTime;
            if (carb < carb_max)
            {
                carb += speed;
            }

            if (lipid < lipid_max)
            {
                lipid += speed;
            }

            if (protein < protein_max)
            {
                protein += speed;
            }

            if (vitamin < vitamin_max)
            {
                vitamin += speed;
            }

            if (mineral < mineral_max)
            {
                mineral += speed;
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

    public void Initialized_BPP()
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
    }
}

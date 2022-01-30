using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodBookPentagon : DynamicPentagon
{
    public FoodBookData fbd;
    float speed;

    float carb;
    float lipid;
    float protein;
    float vitamin;
    float mineral;

    public float carb_max;
    public float lipid_max;
    public float protein_max;
    public float vitamin_max;
    public float mineral_max;

    //int flag_counter = 0;

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
    }

    protected override void Update()
    {
        if (fbd.run_animation)
        {
            speed = 2*Time.deltaTime;
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

    public void Initialized_FBP()
    {
        carb = 0;
        lipid = 0;
        protein = 0;
        vitamin = 0;
        mineral = 0;

        //flag_counter = 0;

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

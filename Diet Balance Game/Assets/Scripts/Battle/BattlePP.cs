using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattlePP : DynamicPentagon
{
    public EnemyEncount ee;
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
            new Parameter( "ビタミン", vitamin),
            new Parameter( "炭水化物", carb),
            new Parameter( "脂質", lipid),
            new Parameter( "タンパク質", protein),
            new Parameter( "ミネラル", mineral),
        };

        //食事で得た栄養素の合計(最低値0，最大値1で正規化)
        carb_max = 1.5f;
        lipid_max = 1.5f;
        protein_max = 1.5f;
        vitamin_max = 1.5f;
        mineral_max = 1.5f;
    }

    protected override void Update()
    {
        if (ee.next)
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


        //値の更新
        m_ParameterList = new List<Parameter>
        {
            new Parameter( "ビタミン", vitamin),
            new Parameter( "炭水化物", carb),
            new Parameter( "脂質", lipid),
            new Parameter( "タンパク質", protein),
            new Parameter( "ミネラル", mineral),
        };

        SetUp();
    }
}

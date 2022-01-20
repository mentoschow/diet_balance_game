using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleEP : DynamicPentagon
{
    public BattleManager bm;

    public float carb;
    public float lipid;
    public float protein;
    public float vitamin;
    public float mineral;

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
    }



    protected override void Update()
    {
        if (bm.run_animation)
        {
            m_ParameterList = new List<Parameter>
            {
                new Parameter( "ビタミン", vitamin),
                new Parameter( "炭水化物", carb),
                new Parameter( "脂質", lipid),
                new Parameter( "タンパク質", protein),
                new Parameter( "ミネラル", mineral),
            };
        }

        SetUp();
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusParameter02 : DynamicPentagon
{
    public EnemImgMng EIM;

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
        m_ParameterList = new List<Parameter>
        {
            new Parameter( "炭水化物", 0),
            new Parameter( "脂質", 0),
            new Parameter( "タンパク質", 0),
            new Parameter( "ビタミン", 0),
            new Parameter( "ミネラル", 0),
        };
    }

    float counter = 0;

    protected override void Update()
    {
        if (EIM.end_enem_down == true && counter < 1.5f)
        {
            counter += 0.01f;
        }

        //値の更新
        m_ParameterList = new List<Parameter>
        {
            new Parameter( "炭水化物", counter),
            new Parameter( "脂質", counter),
            new Parameter( "タンパク質", counter),
            new Parameter( "ビタミン", counter),
            new Parameter( "ミネラル", counter),
        };

        SetUp();
    }
}

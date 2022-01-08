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
            new Parameter( "�Y������", 0),
            new Parameter( "����", 0),
            new Parameter( "�^���p�N��", 0),
            new Parameter( "�r�^�~��", 0),
            new Parameter( "�~�l����", 0),
        };
    }

    float counter = 0;

    protected override void Update()
    {
        if (EIM.end_enem_down == true && counter < 1.5f)
        {
            counter += 0.01f;
        }

        //�l�̍X�V
        m_ParameterList = new List<Parameter>
        {
            new Parameter( "�Y������", counter),
            new Parameter( "����", counter),
            new Parameter( "�^���p�N��", counter),
            new Parameter( "�r�^�~��", counter),
            new Parameter( "�~�l����", counter),
        };

        SetUp();
    }
}

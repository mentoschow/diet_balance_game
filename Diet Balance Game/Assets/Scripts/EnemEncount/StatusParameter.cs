using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusParameter : DynamicPentagon
{

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
    public List<Parameter> m_ParameterList = new List<Parameter>
    {
        new Parameter( "�̗�", 1.0f),
        new Parameter( "�h��", 0.5f),
        new Parameter( "�U����", 0.8f),
        new Parameter( "�h���", 1.0f),
        new Parameter( "�f����", 0.1f),
    };


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

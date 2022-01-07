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
        new Parameter( "‘Ì—Í", 1.0f),
        new Parameter( "–hŒä", 0.5f),
        new Parameter( "UŒ‚—Í", 0.8f),
        new Parameter( "–hŒä—Í", 1.0f),
        new Parameter( "‘f‘‚³", 0.1f),
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

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

    public float carb_sndmax;
    public float lipid_sndmax;
    public float protein_sndmax;
    public float vitamin_sndmax;
    public float mineral_sndmax;

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
            new Parameter( "ビタミン", vitamin),
            new Parameter( "炭水化物", carb),
            new Parameter( "脂質", lipid),
            new Parameter( "タンパク質", protein),
            new Parameter( "ミネラル", mineral),
        };
    }

    protected override void Update()
    {
        if (EIM.end_enem_down == true && end_flag == false && SP01.end_flag == true)
        {
            speed = Time.deltaTime;
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

            //次のパラメータ表示に進むか
            if (flag_counter == 5)
            {
                end_flag = true;
            }
            else
            {
                flag_counter = 0;
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

    public void InitializedSP02()
    {
        carb = 0;
        lipid = 0;
        protein = 0;
        vitamin = 0;
        mineral = 0;

        flag_counter = 0;
        end_flag = false;

        m_ParameterList = new List<Parameter>
        {
            new Parameter( "ビタミン", vitamin),
            new Parameter( "炭水化物", carb),
            new Parameter( "脂質", lipid),
            new Parameter( "タンパク質", protein),
            new Parameter( "ミネラル", mineral),
        };
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusParameter01 : DynamicPentagon
{
    public bool end_flag = false;
    public EnemImgMng EIM;

    float speed;

    float carb;
    float lipid;
    float protein;
    float vitamin;
    float mineral;

    float carb_fstmax;
    float lipid_fstmax;
    float protein_fstmax;
    float vitamin_fstmax;
    float mineral_fstmax;

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

        [Range(0.0f, 1.0f)]
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
            new Parameter( "炭水化物", carb),
            new Parameter( "脂質", lipid),
            new Parameter( "タンパク質", protein),
            new Parameter( "ビタミン", vitamin),
            new Parameter( "ミネラル", mineral),
        };

        //1回目の食事で得た栄養素(最低値0，最大値1で正規化)
        carb_fstmax = 0.2f;
        lipid_fstmax = 0.5f;
        protein_fstmax = 0.4f;
        vitamin_fstmax = 0.5f;
        mineral_fstmax = 0.3f;
    }

    

    protected override void Update()
    {
        if (EIM.end_enem_down == true && end_flag == false)
        {
            speed = Time.deltaTime;
            
            if (carb < carb_fstmax)
            {
                carb += speed;
            }
            else
            {
                flag_counter++;
            }

            if(lipid < lipid_fstmax)
            {
                lipid += speed;
            }
            else
            {
                flag_counter++;
            }

            if (protein < protein_fstmax)
            {
                protein += speed;
            }
            else
            {
                flag_counter++;
            }

            if (vitamin < vitamin_fstmax)
            {
                vitamin += speed;
            }
            else
            {
                flag_counter++;
            }

            if (mineral < mineral_fstmax)
            {
                mineral += speed;
            }
            else
            {
                flag_counter++;
            }

            //次のパラメータ表示に進むか
            if(flag_counter == 5)
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
            new Parameter( "炭水化物", carb),
            new Parameter( "脂質", lipid),
            new Parameter( "タンパク質", protein),
            new Parameter( "ビタミン", vitamin),
            new Parameter( "ミネラル", mineral),
        };

        SetUp();
    }
}

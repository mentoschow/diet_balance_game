using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class FoodData : ScriptableObject
{
    public List<Food> food;

    [System.Serializable]
    public class Food
    {
        public string name;     //食べ物名
        public int energy;      //エネルギー
        public float carb;      //炭水化物（糖質）
        public float lipid;     //脂質
        public float protein;   //タンパク質
        public float vitamin;   //ビタミン  
        public float mineral;   //ミネラル
    }
}

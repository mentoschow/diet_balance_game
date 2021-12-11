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
        public string name;
        public float a;
        public float b;
        public float c;
        public float d;
        public float e;
    }
}

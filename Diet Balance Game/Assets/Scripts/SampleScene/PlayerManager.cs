using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public FoodSelection fs;
    public Sheet1 FoodData;
    public bool isboy;

    private struct FOOD
    {
        public string name;
        public int energy;
        public float carb;
        public float lipid;
        public float protein;
        public float vitamin;
        public float mineral;
        public int ID;
    }

    public struct HERO
    {
        public float carb;
        public float lipid;
        public float protein;
        public float vitamin;
        public float mineral;
        public string age;
        public int statusid;       //normal:0, cold:1, busy:2, fat:3, roughskin:4
    }
    
    public HERO hero;

    private bool first;

    void Awake()
    {
        
    }

    void Start()
    {
        first = true;
    }

    void Update()
    {
        if (fs.next && first)
        {
            
            
            first = false;
        }
    }


    void GetFoodData(FOOD food)
    {
        for (int i = 0; i < FoodData.dataList.Count; i++)
        {
            food.name = FoodData.dataList[i].Name;
            food.carb = FoodData.dataList[i].Carb;
            food.lipid = FoodData.dataList[i].Lipid;
            food.protein = FoodData.dataList[i].Protein;
            food.vitamin = FoodData.dataList[i].Vitamin;
            food.mineral = FoodData.dataList[i].Mineral;
        }
    }
}

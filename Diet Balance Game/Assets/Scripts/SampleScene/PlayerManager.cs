using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public FoodSelection fs;
    public Sheet1 fd;
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

    private FOOD food1;
    private FOOD food2;
    private FOOD food3;
    private FOOD food4;

    public HERO hero;

    private bool first;

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


    void GetFoodData(string name, FOOD food)
    {
        for (int i = 0; i < fd.dataList.Count; i++)
        {
            if (name == fd.dataList[i].Name)
            {
                food.name = fd.dataList[i].Name;
                food.carb = fd.dataList[i].Carb;
                food.lipid = fd.dataList[i].Lipid;
                food.protein = fd.dataList[i].Protein;
                food.vitamin = fd.dataList[i].Vitamin;
                food.mineral = fd.dataList[i].Mineral;
            }
        }
    }
}

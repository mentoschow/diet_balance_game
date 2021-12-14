using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public FoodSelection fs;
    public FoodData fd;
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
        public float a;
        public float b;
        public float c;
        public float d;
        public float e;
        public string age;    
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
            GetFoodData(fs.food1, food1);
            GetFoodData(fs.food2, food2);
            GetFoodData(fs.food3, food3);
            GetFoodData(fs.food4, food4);
            UpdateHero(food1, food2, food3, food4);
            first = false;
        }
    }


    void GetFoodData(string name, FOOD food)
    {
        for (int i = 0; i < fd.food.Count; i++)
        {
            if (name == fd.food[i].name)
            {
                food.name = fd.food[i].name;
                food.carb = fd.food[i].carb;
                food.lipid = fd.food[i].lipid;
                food.protein = fd.food[i].protein;
                food.vitamin = fd.food[i].vitamin;
                food.mineral = fd.food[i].mineral;
            }
        }
    }

    void UpdateHero(FOOD food1, FOOD food2, FOOD food3, FOOD food4)
    {
        hero.a = hero.a + food1.carb + food2.carb + food3.carb + food4.carb;
        hero.b = hero.b + food1.lipid + food2.lipid + food3.lipid + food4.lipid;
        hero.c = hero.c + food1.protein + food2.protein + food3.protein + food4.protein;
        hero.d = hero.d + food1.vitamin + food2.vitamin + food3.vitamin + food4.vitamin;
        hero.e = hero.e + food1.mineral + food2.mineral + food3.mineral + food4.mineral;
    }
}

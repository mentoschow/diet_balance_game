using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public FoodSelection fs;
    public FoodData fd;

    private struct FOOD
    {
        public string name;
        public float a;
        public float b;
        public float c;
        public float d;
        public float e;
    }

    public struct HERO
    {
        public float a;
        public float b;
        public float c;
        public float d;
        public float e;
        public bool isboy;
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
                food.a = fd.food[i].a;
                food.b = fd.food[i].b;
                food.c = fd.food[i].c;
                food.d = fd.food[i].d;
                food.e = fd.food[i].e;
            }
        }
    }

    void UpdateHero(FOOD food1, FOOD food2, FOOD food3, FOOD food4)
    {
        hero.a = hero.a + food1.a + food2.a + food3.a + food4.a;
        hero.b = hero.b + food1.b + food2.b + food3.b + food4.b;
        hero.c = hero.c + food1.c + food2.c + food3.c + food4.c;
        hero.d = hero.d + food1.d + food2.d + food3.d + food4.d;
        hero.e = hero.e + food1.e + food2.e + food3.e + food4.e;
    }
}

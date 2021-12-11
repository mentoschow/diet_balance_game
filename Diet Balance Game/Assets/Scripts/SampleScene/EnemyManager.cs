using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public FoodData enemyData;

    public struct ENEMY
    {
        public string name;
        public float a;
        public float b;
        public float c;
        public float d;
        public float e;
    }

    public ENEMY enemy;

    void Start()
    {
        UpdateEnemy();
    }

    void Update()
    {
        
    }

    void UpdateEnemy()
    {
        enemy.name = enemyData.food[0].name;
        enemy.a = enemyData.food[0].a;
        enemy.b = enemyData.food[0].b;
        enemy.c = enemyData.food[0].c;
        enemy.d = enemyData.food[0].d;
        enemy.e = enemyData.food[0].e;
    }
}

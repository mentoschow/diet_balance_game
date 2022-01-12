using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public FoodData enemyData;

    public struct ENEMY
    {
        public int enemID;
        public int energy;
        public float carb;
        public float lipid;
        public float protein;
        public float vitamin;
        public float mineral;
    }

    public ENEMY enemy;

    void Start()
    {
        //GameObject enemy_img = new GameObject("EnemyImg");
    }

    void Update()
    {
        UpdateEnemy();
    }

    void UpdateEnemy()
    {
        enemy.energy = enemyData.food[0].energy;
        enemy.carb = enemyData.food[0].carb;
        enemy.lipid = enemyData.food[0].lipid;
        enemy.protein = enemyData.food[0].protein;
        enemy.vitamin = enemyData.food[0].vitamin;
        enemy.mineral = enemyData.food[0].mineral;
    }
}

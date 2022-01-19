using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public FoodSelection fs;
    public Sheet1 FoodData;
    public bool isboy;

    [System.Serializable]
    public struct FOOD
    {
        public string name;
        public float energy;
        public float carb;
        public float lipid;
        public float protein;
        public float vitamin;
        public float mineral;
        public int ID;
    }

    [System.Serializable]
    public struct HERO
    {
        public float energy;
        public float carb;
        public float lipid;
        public float protein;
        public float vitamin;
        public float mineral;
        public string age;
        public int statusid;       //normal:0, cold:1, busy:2, fat:3, roughskin:4
        public int day;            //ÉNÉäÉAÇµÇΩì˙êîÇï€ë∂
    }
    
    public HERO hero;

    public HERO baseNut;            //base nutrition that defined by Player's age and gender

    public FOOD selectedFoodData1;  //food data that selected in turn 1.(food1 + food2 + food3)
    public FOOD selectedFoodData2;  //food data that selected in turn 2.(food1 + food2 + food3)
    public FOOD selectedFoodData3;  //food data that selected in turn 3.(food1 + food2 + food3)

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
    
}

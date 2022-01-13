using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodBookButton : MonoBehaviour
{
    public Score score;
    //FoodBookButton
    public void OnClickFoodBook()
    {
        score.foodbookFlag = true;
    }  
}

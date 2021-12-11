using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodSelection : MonoBehaviour
{
    public PlayerManager pm;
    public bool next;

    private GameObject stapleFood;
    private GameObject mainDish;
    private GameObject sideDish;
    private GameObject drink;
    private GameObject others;

    void Start()
    {
        stapleFood = GameObject.Find("stapleFood");
        mainDish = GameObject.Find("mainDish");
        sideDish = GameObject.Find("sideDish");
        drink = GameObject.Find("drink");
        others = GameObject.Find("others");
        StapleFood();
    }

    void Update()
    {
        
    }

    public void StapleFood()
    {
        stapleFood.SetActive(true);
        mainDish.SetActive(false);
        sideDish.SetActive(false);
        drink.SetActive(false);
        others.SetActive(false);
    }

    public void MainDish()
    {
        stapleFood.SetActive(false);
        mainDish.SetActive(true);
        sideDish.SetActive(false);
        drink.SetActive(false);
        others.SetActive(false);
    }

    public void SideDish()
    {
        stapleFood.SetActive(false);
        mainDish.SetActive(false);
        sideDish.SetActive(true);
        drink.SetActive(false);
        others.SetActive(false);
    }

    public void Drink()
    {
        stapleFood.SetActive(false);
        mainDish.SetActive(false);
        sideDish.SetActive(false);
        drink.SetActive(true);
        others.SetActive(false);
    }

    public void Others()
    {
        stapleFood.SetActive(false);
        mainDish.SetActive(false);
        sideDish.SetActive(false);
        drink.SetActive(false);
        others.SetActive(true);
    }

    public void NextScene()
    {
        next = true;
    }
}

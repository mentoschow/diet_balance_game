using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodSelection : MonoBehaviour
{
    public PlayerManager pm;
    public AssetConfig character;
    public bool next;
    public Image hero;

    private GameObject stapleFood;
    private GameObject mainDish;
    private GameObject sideDish;
    private GameObject drink;
    private GameObject others;

    private GameObject FoodSelected1;
    private GameObject FoodSelected2;
    private GameObject FoodSelected3;
    private GameObject FoodSelected4;

    public string food1;
    public string food2;
    public string food3;
    public string food4;

    void Start()
    {
        //LoadCharacter(character.sprites[0], character.sprites[1]);
        stapleFood = GameObject.Find("stapleFood");
        mainDish = GameObject.Find("mainDish");
        sideDish = GameObject.Find("sideDish");
        drink = GameObject.Find("drink");
        others = GameObject.Find("others");
        FoodSelected1 = GameObject.Find("FoodSelected1");
        FoodSelected2 = GameObject.Find("FoodSelected2");
        FoodSelected3 = GameObject.Find("FoodSelected3");
        FoodSelected4 = GameObject.Find("FoodSelected4");
        StapleFood();
    }

    void Update()
    {
        
    }

    public void StapleFood()
    {
        stapleFood.SetActive(true);
        mainDish.SetActive(false);
        //sideDish.SetActive(false);
        //drink.SetActive(false);
        //others.SetActive(false);
    }

    public void MainDish()
    {
        stapleFood.SetActive(false);
        mainDish.SetActive(true);
        //sideDish.SetActive(false);
        //drink.SetActive(false);
        //others.SetActive(false);
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

    public void SelectFood1(GameObject obj)
    {
        FoodSelected1.GetComponent<Image>().sprite = obj.GetComponent<Image>().sprite;
    }
    public void SelectFood2(GameObject obj)
    {
        FoodSelected2.GetComponent<Image>().sprite = obj.GetComponent<Image>().sprite;
    }
    public void SelectFood3(GameObject obj)
    {
        FoodSelected3.GetComponent<Image>().sprite = obj.GetComponent<Image>().sprite;
    }
    public void SelectFood4(GameObject obj)
    {
        FoodSelected4.GetComponent<Image>().sprite = obj.GetComponent<Image>().sprite;
    }

    public void NextScene()
    {
        food1 = FoodSelected1.GetComponent<Image>().sprite.name;
        //food2 = FoodSelected2.GetComponent<Image>().sprite.name;
        //food3 = FoodSelected3.GetComponent<Image>().sprite.name;
        //food4 = FoodSelected4.GetComponent<Image>().sprite.name;
        next = true;
    }

    void LoadCharacter(Sprite boy, Sprite girl)
    {
        if (pm.isboy)
        {
            hero.sprite = boy;
        }
        else
        {
            hero.sprite = girl;
        }
    }
}

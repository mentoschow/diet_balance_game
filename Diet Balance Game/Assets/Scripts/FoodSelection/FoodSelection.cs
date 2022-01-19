using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodSelection : MonoBehaviour
{
    public PlayerManager pm;
    public AssetConfig character;
    public AssetConfig FoodImage;
    public Sheet1 FoodData;
    public bool next;
    public Image hero;
    public GameObject comfirm;
    public GameObject filter;
    public GameObject menu1;
    public GameObject menu2;
    public GameObject menu3;
    public Image turn;
    public AssetConfig turn_sprite;
    public List<Image> comfirmImage;
    public int comfirmEncount;
    public int comfirmEncount_temp;

    public List<Toggle> food;
    public List<Image> foodTex;

    [SerializeField] private int turnEncount;
    [SerializeField] private int menuEncount;
    [SerializeField] private int selectedEncount;
    [SerializeField] private int[] selectedFood = new int[3];
    [SerializeField] private int[] randomNum = new int[18];
    private int tempNum;
    private int tempSort;

    void Start()
    {
        turnEncount = 1;
        Initialized();       
    }

    void Update()
    {
        LoadCharacter(character.sprites[0], character.sprites[1]);
        LoadTurnImage(turnEncount);
        switch (menuEncount)
        {
            case 1:
                menu1.SetActive(true);
                menu2.SetActive(false);
                menu3.SetActive(false);
                break;
            case 2:
                menu1.SetActive(false);
                menu2.SetActive(true);
                menu3.SetActive(false);
                break;
            case 3:
                menu1.SetActive(false);
                menu2.SetActive(false);
                menu3.SetActive(true);
                break;
        }
    }

    void Initialized()
    {
        next = false;
        menuEncount = 1;
        comfirm.SetActive(false);
        filter.SetActive(false);
        for(int i = 0; i < food.Count; i++)
        {
            food[i].isOn = false;
        }
        selectedEncount = 0;
        GetRandomNumbers();
        LoadFoodTexture();
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

    void LoadTurnImage(int turnEncount)
    {
        turn.sprite = turn_sprite.sprites[turnEncount - 1];
    }

    void LoadFoodTexture()
    {
        for(int i = 0; i < 18; i++)
        {
            foodTex[i].sprite = FoodImage.sprites[randomNum[i]];
        }
    }

    public void NextMenu()
    {
        menuEncount++;
    }

    public void FrontMenu()
    {
        menuEncount--;
    }

    public void StartComfirm()  // to comfirm
    {
        comfirmEncount_temp = 0;
        for(int i = 0; i < 3; i++)
        {
            for (comfirmEncount = comfirmEncount_temp; comfirmEncount < food.Count; comfirmEncount++)
            {
                if (food[comfirmEncount].isOn == true)
                {
                    comfirmImage[i].sprite = FoodImage.sprites[randomNum[comfirmEncount]];
                    selectedFood[i] = randomNum[comfirmEncount];  //record the number of food.
                    Debug.Log(selectedFood[i]);
                    comfirmEncount_temp = comfirmEncount + 1;
                    break;
                }
            }
        }
        filter.SetActive(true);
        comfirm.SetActive(true);
    }

    public void BackToSelection()
    {
        filter.SetActive(false);
        comfirm.SetActive(false);
    }

    public void NextStage()
    {
        switch (turnEncount)
        {
            case 1:
                turnEncount++;
                RecordFoodData(selectedFood[0], selectedFood[1], selectedFood[2], ref pm.selectedFoodData1);  //do recording              
                Initialized();
                break;
            case 2:
                turnEncount++;
                RecordFoodData(selectedFood[0], selectedFood[1], selectedFood[2], ref pm.selectedFoodData2);  //do recording
                Initialized();
                break;
            case 3:
                turnEncount = 1;
                RecordFoodData(selectedFood[0], selectedFood[1], selectedFood[2], ref pm.selectedFoodData3);  //do recording
                Initialized();
                next = true;
                break;
        }
    }

    public void SelectedEncount(Toggle toggle)
    {
        if (toggle.isOn == false)
        {
            selectedEncount--;
        }
        if (toggle.isOn == true)
        {
            if (selectedEncount < 3)
            {
                selectedEncount++;
            }
            else
            {
                print("can not select.");
                toggle.isOn = false;
                selectedEncount = 3;
            }
        }      
    }

    public void RecordFoodData(int a, int b, int c, ref PlayerManager.FOOD food)
    {
        food.energy = FoodData.dataArray[a].Energy + FoodData.dataArray[b].Energy + FoodData.dataArray[c].Energy;
        food.carb = FoodData.dataArray[a].Carb + FoodData.dataArray[b].Carb + FoodData.dataArray[c].Carb;
        food.lipid = FoodData.dataArray[a].Lipid + FoodData.dataArray[b].Lipid + FoodData.dataArray[c].Lipid;
        food.protein = FoodData.dataArray[a].Protein + FoodData.dataArray[b].Protein + FoodData.dataArray[c].Protein;
        food.vitamin = FoodData.dataArray[a].Vitamin + FoodData.dataArray[b].Vitamin + FoodData.dataArray[c].Vitamin;
        food.mineral = FoodData.dataArray[a].Mineral + FoodData.dataArray[b].Mineral + FoodData.dataArray[c].Mineral;
    }

    private void GetRandomNumbers()
    {
        for(int i = 0; i < 18; i++)
        {
            cc: tempNum = Random.Range(0, 30);
            //IsRepeat
            for(int j = 0; j < i; j++)
            {
                if(tempNum == randomNum[j])
                {
                    goto cc;
                }
            }
            randomNum[i] = tempNum;
        }
        //Sort
        for(int m = 0; m < 18; m++)
        {
            for(int n = m + 1; n < 18; n++)
            {
                if (randomNum[m] > randomNum[n])
                {
                    tempSort = randomNum[m];
                    randomNum[m] = randomNum[n];
                    randomNum[n] = tempSort;
                }
            }
        }
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodBook : MonoBehaviour
{
    //Flag
    public bool foodbookDataFlag;

    //Data
    public AssetConfig food_tex;
    public AssetConfig number_tex;
    public Sheet1 food_data;
    public Score score;

    //Objects
    public List<Image> food_img;
    public List<Text> food_name;
    public Image page_img;
    public GameObject nextPage;  //right button
    public GameObject frontPage;  //left button
    public FoodBookData fbd;

    [SerializeField] private int page_num;
    [SerializeField] private bool first;  //is first time entering this scene?

    void Start()
    {
        page_num = 1;
        first = true;
        foodbookDataFlag = false;
    }

    void Update()
    {
        LoadPageImage();
        LoadFood();
        if (score.foodbookFlag && first)
        {
            page_num = 1;
            first = false;
        }
        nextPage.SetActive(true);
        frontPage.SetActive(true);
        if (page_num == 1)
        {
            frontPage.SetActive(false);
        }
        if (page_num == 7)
        {
            nextPage.SetActive(false);
        }
    }

    void LoadPageImage()
    {
        page_img.sprite = number_tex.sprites[page_num - 1];
    }

    void LoadFood()
    {
        for (int i = 0; i < 6; i++)  // [6 * page_num - (6 - i)] is the encount of food.(ID - 1)
        {
            food_img[i].sprite = food_tex.sprites[6 * page_num - (6 - i)];
            food_name[i].text = food_data.dataArray[6 * page_num - (6 - i)].Name_Jp;  // load food data
        }
    }

    public void NextPage()
    {
        page_num ++;
        if (page_num > 7)
        {
            page_num = 7;
        }
    }

    public void FrontPage()
    {
        page_num--;     
        if (page_num < 1)
        {
            page_num = 1;
        }
    }

    public void Back()
    {
        score.foodbookFlag = false;
        first = true;
    }

    public void OnClickFoodDataMenu1()
    {
        foodbookDataFlag = true;
        fbd.DataID = 6 * page_num - (6 - 0);
    }

    public void OnClickFoodDataMenu2()
    {
        foodbookDataFlag = true;
        fbd.DataID = 6 * page_num - (6 - 1);
    }

    public void OnClickFoodDataMenu3()
    {
        foodbookDataFlag = true;
        fbd.DataID = 6 * page_num - (6 - 2);
    }

    public void OnClickFoodDataMenu4()
    {
        foodbookDataFlag = true;
        fbd.DataID = 6 * page_num - (6 - 3);
    }

    public void OnClickFoodDataMenu5()
    {
        foodbookDataFlag = true;
        fbd.DataID = 6 * page_num - (6 - 4);
    }

    public void OnClickFoodDataMenu6()
    {
        foodbookDataFlag = true;
        fbd.DataID = 6 * page_num - (6 - 5);
    }
}

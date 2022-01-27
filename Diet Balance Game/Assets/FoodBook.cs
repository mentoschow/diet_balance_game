using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodBook : MonoBehaviour
{
    //Data
    public AssetConfig food_tex;
    public AssetConfig number_tex;
    public Sheet1 food_data;
    public Score score;

    //Objects
    public List<Image> food_img;
    public List<Text> food_name;
    public Image page_img;
    public GameObject nextPage;
    public GameObject frontPage;

    [SerializeField] private int page_num;
    [SerializeField] private bool first;

    void Start()
    {
        page_num = 1;
        first = true;
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
            food_name[i].text = food_data.dataArray[6 * page_num - (6 - i)].Name_Jp;
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
}

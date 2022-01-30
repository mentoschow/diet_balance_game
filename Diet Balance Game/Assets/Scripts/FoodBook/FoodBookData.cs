using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodBookData : MonoBehaviour
{
    public bool run_animation;

    public int DataID;

    //Data
    public AssetConfig food_tex;
    public Sheet1 food_data;

    //Object
    [SerializeField] Image food_img;
    [SerializeField] Text food_txt;
    public FoodBook fd;
    public FoodBookPentagon fbp;


    // Start is called before the first frame update
    void Start()
    {
        run_animation = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(fd.foodbookDataFlag)
        {
            run_animation = true;
            transform_nutParam_to_pentagonParam();
            food_img.sprite = food_tex.sprites[DataID];
            food_txt.text = food_data.dataArray[DataID].Name_Jp;  // load food data
        }
        
    }

    public void onClickFoodBack()
    {
        fd.foodbookDataFlag = false;
        run_animation = false;
        fbp.Initialized_FBP();
    }

    //Transform parameter
    void transform_nutParam_to_pentagonParam()
    {
        float range_max = 3.0f;
        //float max_param = 1.7f;

        //sum player's three selection
        float carb_p, lipid_p, protein_p, vitamin_p, mineral_p;
        carb_p = food_data.dataArray[DataID].Carbohydrates;
        lipid_p = food_data.dataArray[DataID].Lipids;
        protein_p = food_data.dataArray[DataID].Protein;
        vitamin_p = food_data.dataArray[DataID].Vitamin;
        mineral_p = food_data.dataArray[DataID].Mineral;

        fbp.vitamin_max = range_max * vitamin_p / 129;
        fbp.carb_max = range_max * carb_p / 318;
        fbp.lipid_max = range_max * lipid_p / 64;
        fbp.protein_max = range_max * protein_p / 97;
        fbp.mineral_max = range_max * mineral_p / 11218;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Result : MonoBehaviour
{
    public bool next = false;
    public bool resultButtonFlag = false;

    public BattleManager bm;
    public AssetConfig buttonImg;
    public AssetConfig result_text;

    [SerializeField] Image ResultText = null;      //プレイヤー画像
    [SerializeField] Button NextButton = null;         //吹き出し画像 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (bm.battle_result == true)
        {
            ResultText.sprite = result_text.sprites[0];
            NextButton.GetComponent<Image>().sprite = buttonImg.sprites[0];

            if (resultButtonFlag)
            {
                next = true;
            }
        }
        else
        {
            ResultText.sprite = result_text.sprites[1];
            NextButton.GetComponent<Image>().sprite = buttonImg.sprites[1];

            if(resultButtonFlag)
            {
                Application.Quit();
            }
        }
        
    }
}

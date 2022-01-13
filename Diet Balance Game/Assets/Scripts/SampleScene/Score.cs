using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;    //UIの追加

public class Score : MonoBehaviour
{
    public bool next = false;
    public bool foodbookFlag = false;

    public PlayerManager pm;
    public Performance p;
    public AssetConfig character;

    [SerializeField] Image PlayerImg = null;      //プレイヤー画像

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //プレイヤー画像の表示
        if (pm.isboy == true)
        {
            PlayerImg.sprite = character.sprites[0];
        }
        else
        {
            PlayerImg.sprite = character.sprites[1];
        }
    }
}

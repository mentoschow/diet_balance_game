using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;    //UIの追加

public class PlayerStatus : MonoBehaviour
{
    public bool next;           //シーン遷移用のブール変数
    public PlayerManager pm;
    public Score score;
    public AssetConfig character;
    public AssetConfig popup;
    public AssetConfig word;

    [SerializeField] Image PlayerImg = null;      //プレイヤー画像
    [SerializeField] Image PopImg = null;         //吹き出し画像 

    [SerializeField] Image Word1;       //文字1
    [SerializeField] Image Word2;       //文字2
    [SerializeField] Image Word3;       //文字3

    int status;

    // Start is called before the first frame update
    void Start()
    {
        Random.InitState(System.DateTime.Now.Millisecond);  //時間による乱数初期化
        pm.hero.statusid = Random.Range(0, 5);              //初日（一日目）のステータス 
        Debug.Log("PS" + status);
    }

    // Update is called once per frame
    void Update()
    {
        status = pm.hero.statusid;      //プレイヤーのステータスID

        //プレイヤー画像の表示
        if (pm.isboy == true)
        {
            PlayerImg.sprite = character.sprites[status * 2];
        }
        else
        {
            PlayerImg.sprite = character.sprites[status * 2 + 1];
        }

        //Pop画像の表示
        PopImg.sprite = popup.sprites[status];

        //文字画像の表示
        if (status == 0)
        {
            //「普通」
            Word1.sprite = word.sprites[0];
            Word2.sprite = word.sprites[1];
        }
        else if (status == 1)
        {
            //「風邪」
            Word1.sprite = word.sprites[2];
            Word2.sprite = word.sprites[3];
        }
        else if (status == 2)
        {
            //「忙しい」
            Word1.sprite = word.sprites[4];
            Word2.sprite = word.sprites[5];
            Word3.sprite = word.sprites[6];
        }
        else if (status == 3)
        {
            //「肥満」
            Word1.sprite = word.sprites[7];
            Word2.sprite = word.sprites[8];
        }
        else if (status == 4)
        {
            //「肌荒れ」
            Word1.sprite = word.sprites[9];
            Word2.sprite = word.sprites[10];
            Word3.sprite = word.sprites[11];
        }

        if (score.next)
        {
            if(Input.GetMouseButtonDown(0))
            {
                next = true;
            }
        }
        
    }
}

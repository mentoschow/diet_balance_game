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

    public AssetConfig backimg;
    public AssetConfig character;
    public AssetConfig popup;
    public AssetConfig word;

    Image Background = null;                      //背景画像
    [SerializeField] Image PlayerImg = null;      //プレイヤー画像
    [SerializeField] Image PopImg = null;         //吹き出し画像 

    [SerializeField] Image Word1;       //文字1
    [SerializeField] Image Word2;       //文字2
    [SerializeField] Image Word3;       //文字3

    int status;

    // Start is called before the first frame update
    void Start()
    {
        Background = this.gameObject.GetComponent<Image>();
        Random.InitState(System.DateTime.Now.Millisecond);  //時間による乱数初期化
        pm.hero.statusid = 0;//Random.Range(0, 5);              //初日（一日目）のステータス 

        Word1.gameObject.SetActive(false);
        Word2.gameObject.SetActive(false);
        Word3.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        status = pm.hero.statusid;      //プレイヤーのステータスID

        if (score.next && next == false)
        {
            LoadImages();

            if (Input.GetMouseButtonDown(0))
            {
                next = true;
            }
        }
        
    }

    void LoadImages()
    {
        //プレイヤー画像の表示
        if (pm.isboy == true)
        {
            PlayerImg.sprite = character.sprites[status * 2];
        }
        else
        {
            PlayerImg.sprite = character.sprites[status * 2 + 1];
        }

        //背景画像の表示
        Background.sprite = backimg.sprites[status];
        //Pop画像の表示
        PopImg.sprite = popup.sprites[status];

        //文字画像の表示
        if (status == 0)
        {
            //「普通」
            Word1.gameObject.SetActive(true);
            Word2.gameObject.SetActive(true);
            Word3.gameObject.SetActive(false);
            Word1.sprite = word.sprites[0];
            Word2.sprite = word.sprites[1];
            Word3.sprite = null;
        }
        else if (status == 1)
        {
            //「風邪」
            Word1.gameObject.SetActive(true);
            Word2.gameObject.SetActive(true);
            Word3.gameObject.SetActive(false);
            Word1.sprite = word.sprites[2];
            Word2.sprite = word.sprites[3];
        }
        else if (status == 2)
        {
            //「忙しい」
            Word1.gameObject.SetActive(true);
            Word2.gameObject.SetActive(true);
            Word3.gameObject.SetActive(true);
            Word1.sprite = word.sprites[4];
            Word2.sprite = word.sprites[5];
            Word3.sprite = word.sprites[6];
        }
        else if (status == 3)
        {
            //「肥満」
            Word1.gameObject.SetActive(true);
            Word2.gameObject.SetActive(true);
            Word3.gameObject.SetActive(false);
            Word1.sprite = word.sprites[7];
            Word2.sprite = word.sprites[8];
        }
        else if (status == 4)
        {
            //「肌荒れ」
            Word1.gameObject.SetActive(true);
            Word2.gameObject.SetActive(true);
            Word3.gameObject.SetActive(true);
            Word1.sprite = word.sprites[9];
            Word2.sprite = word.sprites[10];
            Word3.sprite = word.sprites[11];
        }
    }

    void Initialize()
    {
        Word1.gameObject.SetActive(false);
        Word2.gameObject.SetActive(false);
        Word3.gameObject.SetActive(false);
    }
}

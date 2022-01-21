using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Result : MonoBehaviour
{
    public bool next = false;

    public Canvas gameover;

    public PlayerManager pm;
    public BattleManager bm;
    public AssetConfig resultChara;
    public AssetConfig result_text;
    public AssetConfig DayNumImg;

    [SerializeField] Image character = null;
    [SerializeField] Image ResultText = null;      //�v���C���[�摜
    [SerializeField] Image DayText = null;        //���B���C���I���̃e�L�X�g
    [SerializeField] Image Day01 = null;        //���ɂ��̈�̈�
    [SerializeField] Image Day02 = null;        //���ɂ��̏\�̈�

    //Flags of function
    bool dayflag = true;
    bool imageflag = true;

    // Start is called before the first frame update
    void Start()
    {
        pm.hero.day = 1;
        gameover.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        int status = pm.hero.statusid;

        if (bm.next)
        {
            //Set Day Image
            if (dayflag)
            {
                DayDisplay();
            }

            //Set some images
            if (imageflag)
            {
                ImageDisplay();
            }

            //Change processing by battle result
            if (bm.battle_result == true)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    next = true;
                    Initialize();
                }
            }
            else
            {
               if (Input.GetMouseButtonDown(0))
               {
                   this.enabled = false;
                   Initialize();
                   gameover.enabled = true;
               }
            }
        }  
    }

    void DayDisplay()
    {
        int day = pm.hero.day;
        int day1;
        int day2;

        //�����̕\��
        if (day < 10)
        {
            Day01.sprite = DayNumImg.sprites[day];
            Day02.gameObject.SetActive(false);
        }
        else
        {
            day1 = day % 10;
            day2 = day / 10;
            Day02.gameObject.SetActive(true);
            Day01.sprite = DayNumImg.sprites[day1];
            Day02.sprite = DayNumImg.sprites[day2];
        }

        dayflag = false;
    }

    void ImageDisplay()
    {
        //���������ɂ���āC�\����ς���
        if (bm.battle_result == true)
        {
            if (pm.isboy)
            {
                character.sprite = resultChara.sprites[0];  //boy
            }
            else
            {
                character.sprite = resultChara.sprites[1];  //girl
            }
            ResultText.sprite = result_text.sprites[0];
            DayText.sprite = result_text.sprites[2];
        }
        else
        {
            character.sprite = resultChara.sprites[2];      //mother
            ResultText.sprite = result_text.sprites[1];
            DayText.sprite = result_text.sprites[3];
        }

        imageflag = false;
    }

    void Initialize()
    {
        dayflag = true;
        imageflag = true;
    }
}

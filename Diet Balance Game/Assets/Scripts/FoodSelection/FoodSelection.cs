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
    public GameObject comfirm;
    public GameObject filter;
    public GameObject menu1;
    public GameObject menu2;
    public GameObject menu3;
    public Image turn;
    public AssetConfig turn_sprite;

    public Toggle food1;

    [SerializeField]
    private int turnEncount;
    [SerializeField]
    private int menuEncount;

    

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
        food1.isOn = false;
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
                menuEncount = 1;
                //do record
                Initialized();
                break;
            case 2:
                turnEncount++;
                menuEncount = 1;
                //do record
                Initialized();
                break;
            case 3:
                turnEncount = 1;
                menuEncount = 1;
                //do record
                next = true;
                break;
        }
    }
}

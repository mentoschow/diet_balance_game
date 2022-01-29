using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AVGMachine : MonoBehaviour
{
    public enum STATE
    {
        OFF,
        TYPING,
        PAUSED
    }
    public STATE state;
    private bool justEnter;

    public Dialog dialog;
    public AssetConfig characterSprite;
    public UIPanel UIPanel;
    public PlayerManager pm;
    public Performance pf;
    public AudioSource typing_sound;
    public Image next_img;
    public AssetConfig tutorial_tex;
    public Image tutorial_img;
    public AudioSource skip_sound;

    [SerializeField] private int currentLine;
    private string targetString;
    [SerializeField] private float timer;
    [SerializeField] private float typingSpeed;
    [SerializeField] private float fadein_timer;
    private float fadein_time = 0.8f;

    void Start()
    {
        state = STATE.OFF;       
        justEnter = true;
        typingSpeed = 10f;
        fadein_timer = 0;
        tutorial_img.color = new Color(1, 1, 1, 0);
    }

    void Update()
    {
        switch (state)
        {
            case STATE.OFF:               
                if (justEnter)
                {
                    Init();
                    //LoadCharacter(characterSprite.sprites[0], characterSprite.sprites[1]);
                    justEnter = false;
                }
                fadein_timer = 0;
                typing_sound.Stop();
                break;
            case STATE.TYPING:
                if (justEnter)
                {
                    ShowUI();
                    //LoadCharacter(characterSprite.sprites[0], characterSprite.sprites[1]);                    
                    LoadContent(dialog.contents[currentLine].showCharacter, dialog.contents[currentLine].dialogText);                    
                    timer = 0;
                    justEnter = false;
                }
                switch (currentLine)
                {
                    case 7:                        
                        LoadTutorialImage(0);
                        break;
                    case 8:
                        LoadTutorialImage(1);
                        break;
                    case 9:
                        LoadTutorialImage(2);
                        break;
                    case 10:
                        LoadTutorialImage(3);
                        break;
                    case 11:
                        LoadTutorialImage(4);
                        break;
                    case 13:
                        LoadTutorialImage(5);
                        break;
                    case 15:
                        LoadTutorialImage(6);
                        break;
                    case 20:
                        tutorial_img.color = new Color(1, 1, 1, 0);
                        break;
                }
                UIPanel.contentText.fontSize = 60;
                if (currentLine == dialog.contents.Count - 1)
                {
                    UIPanel.contentText.fontSize = 100;
                }
                checkTypingFinished();
                UpdateContentString();
                if (!typing_sound.isPlaying)
                {
                    typing_sound.Play();
                    //Debug.Log(typing_sound.isPlaying);
                }
                next_img.color = new Color(1, 1, 1, 0);
                break;
            case STATE.PAUSED:
                if (justEnter)
                {

                    justEnter = false;
                }
                switch (currentLine)
                {
                    case 7:
                        tutorial_img.color = new Color(1, 1, 1, 1);
                        break;
                    case 8:
                        tutorial_img.color = new Color(1, 1, 1, 1);
                        break;
                    case 9:
                        tutorial_img.color = new Color(1, 1, 1, 1);
                        break;
                    case 10:
                        tutorial_img.color = new Color(1, 1, 1, 1);
                        break;
                    case 11:
                        tutorial_img.color = new Color(1, 1, 1, 1);
                        break;
                    case 13:
                        tutorial_img.color = new Color(1, 1, 1, 1);
                        break;
                    case 15:
                        tutorial_img.color = new Color(1, 1, 1, 1);
                        break;
                }
                if (typing_sound.isPlaying)
                {
                    typing_sound.Stop();
                    //Debug.Log(typing_sound.isPlaying);
                }
                fadein_timer = 0;
                next_img.color = new Color(1, 1, 1, 1);
                break;
        }
    }
    public void startAVG()
    {
        GoToState(STATE.TYPING);
    }

    public void userClicked()
    {
        switch (state)
        {
            case STATE.TYPING:
                typingSpeed = 60f;
                break;
            case STATE.PAUSED:
                typingSpeed = 15f;
                NextLine();
                if (currentLine >= dialog.contents.Count)
                {
                    GoToState(STATE.OFF);
                    pf.next = true;  //may need to be corrected
                }
                else
                {
                    GoToState(STATE.TYPING);
                }

                break;
        }
    }

    private void checkTypingFinished()
    {
        if (state == STATE.TYPING)
        {
            
            if ((int)Mathf.Floor(timer * typingSpeed) >= targetString.Length)
            {
                
                GoToState(STATE.PAUSED);
            }
        }
    }

    private void GoToState(STATE next)
    {
        state = next;
        justEnter = true;
    }

    private void Init()
    {
        UIPanel.ShowContentBg(false);
        UIPanel.ShowMainCharacter(false);
        UIPanel.ShowContentText(false);
        currentLine = 0;
    }

    void ShowUI()
    {
        UIPanel.ShowContentBg(true);
        UIPanel.ShowMainCharacter(true);
        UIPanel.ShowContentText(true);
    }

    void NextLine()
    {       
        currentLine++;
    }

    void LoadContent(bool characterDisplay, string text)
    {
        targetString = text;
        UIPanel.ShowMainCharacter(characterDisplay);
    }

    void UpdateContentString()
    {
        timer += Time.deltaTime;
        string tempString = targetString.Substring(0, Mathf.Min((int)Mathf.Floor(timer * typingSpeed), targetString.Length));
        UIPanel.SetContentText(tempString);
    }

    void LoadCharacter(Sprite boy, Sprite girl)
    {
        if (pm.isboy)
        {
            UIPanel.LoadCharacterSprite(boy);
        }
        else
        {
            UIPanel.LoadCharacterSprite(girl);
        }
    }

    void LoadTutorialImage(int id)
    {        
        fadein_timer += Time.deltaTime;
        if(fadein_timer > fadein_time)
        {
            fadein_timer = fadein_time;
        }
        tutorial_img.sprite = tutorial_tex.sprites[id];
        tutorial_img.color = new Color(1, 1, 1, fadein_timer / fadein_time);
    }

    public void Skip()
    {
        pf.next = true;
        GoToState(STATE.OFF);
        skip_sound.Play();
    }
}

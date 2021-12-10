using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    [Range(1,50)]
    public float typingSpeed;

    [SerializeField]
    private int currentLine;
    private string targetString;
    [SerializeField]
    private float timer;

    void Start()
    {
        state = STATE.OFF;       
        justEnter = true;
        typingSpeed = 20f;
    }

    void Update()
    {
        switch (state)
        {
            case STATE.OFF:               
                if (justEnter)
                {
                    Init();
                    LoadCharacter(characterSprite.boy, characterSprite.girl);
                    justEnter = false;
                }
                break;
            case STATE.TYPING:
                if (justEnter)
                {
                    ShowUI();
                    LoadContent(dialog.contents[currentLine].showCharacter, dialog.contents[currentLine].dialogText);
                    timer = 0;
                    justEnter = false;
                }
                checkTypingFinished();
                UpdateContentString();
                break;
            case STATE.PAUSED:
                if (justEnter)
                {

                    justEnter = false;
                }
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
                break;
            case STATE.PAUSED:
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
        if (pm.isboy == true)
        {
            UIPanel.LoadCharacterSprite(boy);
        }
        else
        {
            UIPanel.LoadCharacterSprite(girl);
        }
    }
}

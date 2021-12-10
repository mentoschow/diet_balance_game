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

    [SerializeField]
    private int currentLine;  //current dialog

    void Start()
    {
        state = STATE.OFF;       
        justEnter = true;
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
                    justEnter = false;
                }
                checkTypingFinished();
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
                    pf.next = true;  //need to be corrected
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
            GoToState(STATE.PAUSED);
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
        UIPanel.SetContentText(text);
        UIPanel.ShowMainCharacter(characterDisplay);
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

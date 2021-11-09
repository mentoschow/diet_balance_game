using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    //public List<string> contents;
    public Dialog dialog;
    public AssetConfig characterSprite;
    public UIPanel UIPanel;
    public Canvas select;
    public SelectCharacter selectCharacter;

    [SerializeField]
    private int currentLine;  //current dialog

    void Start()
    {
        Init();
        select.enabled = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))  //Show UI Panel when H is pressed.
        {
            Init();
            LoadCharacter(characterSprite.boy, characterSprite.girl);
            ShowUI();
        }

        if (Input.GetMouseButtonDown(0))
        {
            NextLine(); 
            if (currentLine >= dialog.contents.Count)  //Close UI Panel when dialog finished.
            {
                currentLine = dialog.contents.Count;
                Init();
            }
            LoadContent(dialog.contents[currentLine].showCharacter, dialog.contents[currentLine].dialogText);
        }
        
    }

    private void Init()  //³õÆÚ»¯
    {
        HideUI();
        currentLine = 0;
        UIPanel.SetContentText("");
        LoadContent(dialog.contents[currentLine].showCharacter, dialog.contents[currentLine].dialogText);
    }

    void ShowUI()
    {
        UIPanel.ShowCanvas(true);
    }

    void HideUI()
    {
        UIPanel.ShowCanvas(false);
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
        if (selectCharacter.isBoy == true)
        {
            UIPanel.LoadCharacterSprite(boy);
        }
        else
        {
            UIPanel.LoadCharacterSprite(girl);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BattleButton : MonoBehaviour
{
    public bool next = false;

    public StatusParameter03 SP03;
    Button NextButton;
    Animator ButtonAnime;

    // Start is called before the first frame update
    void Start()
    {
        NextButton = GetComponent<Button>();
        ButtonAnime = GetComponent<Animator>();

        ButtonAnime.SetTrigger("Highlighted");
    }

    // ボタンが押された場合、今回呼び出される関数
    public void OnClick()
    {
        if(SP03.end_flag == true)
        {
            next = true;
            Debug.Log("押された!");  // ログを出力
        }
        
    }
}

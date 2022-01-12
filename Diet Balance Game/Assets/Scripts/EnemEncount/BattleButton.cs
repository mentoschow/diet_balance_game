using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BattleButton : MonoBehaviour
{
    Button NextButton;
    Animator ButtonAnime;

    // Start is called before the first frame update
    void Start()
    {
        NextButton = GetComponent<Button>();
        ButtonAnime = GetComponent<Animator>();

        ButtonAnime.SetTrigger("Highlighted");
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}

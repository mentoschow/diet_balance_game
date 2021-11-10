using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadCharacter : MonoBehaviour
{
    public bool isBoy;
    public Sprite[] sprites;
    public Image character;

    void Start()
    {
        isBoy = GameObject.Find("Data").GetComponent<SelectCharacter>().isBoy;

        if (isBoy == true)
        {
            character.sprite = sprites[0];
        }
        else
        {
            character.sprite = sprites[1];
        }
    }
}

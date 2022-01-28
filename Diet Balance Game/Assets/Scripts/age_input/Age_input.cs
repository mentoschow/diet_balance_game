using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class Age_input : MonoBehaviour
{
    public PlayerManager pm;
    public SelectCharacter sc;
    public bool next = false;

    public AssetConfig numbers_tex;
    public List<Image> age;

    [SerializeField] private int num_count = 0;

    public void Update()
    {
        if(sc.next && !next)
        {
            GetAge();
        }   
    }

    public void GetAge()
    {
        if(Input.GetKeyDown(KeyCode.Alpha0) || Input.GetKeyDown(KeyCode.Keypad0))
        {
            //load texture
            if(0 <= num_count && num_count < 2)
            {
                age[num_count].sprite = numbers_tex.sprites[0];
                num_count++;
            }           
        }
        if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1))
        {
            //load texture
            if (0 <= num_count && num_count < 2)
            {
                age[num_count].sprite = numbers_tex.sprites[1];
                num_count++;
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2))
        {
            //load texture
            if (0 <= num_count && num_count < 2)
            {
                age[num_count].sprite = numbers_tex.sprites[2];
                num_count++;
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3))
        {
            //load texture
            if (0 <= num_count && num_count < 2)
            {
                age[num_count].sprite = numbers_tex.sprites[3];
                num_count++;
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Keypad4))
        {
            //load texture
            if (0 <= num_count && num_count < 2)
            {
                age[num_count].sprite = numbers_tex.sprites[4];
                num_count++;
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha5) || Input.GetKeyDown(KeyCode.Keypad5))
        {
            //load texture
            if (0 <= num_count && num_count < 2)
            {
                age[num_count].sprite = numbers_tex.sprites[5];
                num_count++;
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha6) || Input.GetKeyDown(KeyCode.Keypad6))
        {
            //load texture
            if (0 <= num_count && num_count < 2)
            {
                age[num_count].sprite = numbers_tex.sprites[6];
                num_count++;
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha7) || Input.GetKeyDown(KeyCode.Keypad7))
        {
            //load texture
            if (0 <= num_count && num_count < 2)
            {
                age[num_count].sprite = numbers_tex.sprites[7];
                num_count++;
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha8) || Input.GetKeyDown(KeyCode.Keypad8))
        {
            //load texture
            if (0 <= num_count && num_count < 2)
            {
                age[num_count].sprite = numbers_tex.sprites[8];
                num_count++;
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha9) || Input.GetKeyDown(KeyCode.Keypad9))
        {
            //load texture
            if (0 <= num_count && num_count < 2)
            {
                age[num_count].sprite = numbers_tex.sprites[9];
                num_count++;
            }
        }
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            //delete texture
            if (0 < num_count && num_count <= 2)
            {
                num_count--;
                age[num_count].sprite = numbers_tex.sprites[0];
            }          
        }
        if (num_count > 2)
        {
            num_count = 2;
        }
        if (num_count < 0)
        {
            num_count = 0;
        }

        if(Input.GetKeyDown(KeyCode.KeypadEnter)|| Input.GetKeyDown(KeyCode.Return))
        {
            pm.hero.age = age[0].sprite.name + age[1].sprite.name;
            next = true;
        }
    }
    
    public void OK()
    {
        pm.hero.age = age[0].sprite.name + age[1].sprite.name;
        next = true;
    }
}

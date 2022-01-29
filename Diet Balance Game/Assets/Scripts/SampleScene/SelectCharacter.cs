using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCharacter : MonoBehaviour
{
    public bool next = false;
    public PlayerManager pm;
    public AudioSource select_sound;

    public void SelectBoy()
    {
        pm.isboy = true;
        next = true;
        select_sound.Play();
    }

    public void SelectGirl()
    {
        pm.isboy = false;
        next = true;
        select_sound.Play();
    }
}

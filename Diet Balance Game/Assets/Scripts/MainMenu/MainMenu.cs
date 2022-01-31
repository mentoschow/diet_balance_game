using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public AudioSource click_sound;
    public Canvas mainmenu;
    public Canvas settings;
    public Slider volume;

    private void Awake()
    {
        mainmenu.enabled = true;
        settings.enabled = false;
    }

    private void Update()
    {
        AudioListener.volume = volume.value;
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void Click()
    {
        click_sound.Play();
    }

    public void GoSettings()
    {
        mainmenu.enabled = false;
        settings.enabled = true;
    }

    public void BackMainMenu()
    {
        mainmenu.enabled = true;
        settings.enabled = false;
    }
}

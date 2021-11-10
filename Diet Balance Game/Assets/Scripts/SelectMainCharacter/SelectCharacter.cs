using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectCharacter : MonoBehaviour
{
    public bool isBoy;

    void Start()
    {
        GameObject.DontDestroyOnLoad(gameObject);
    }

    public void SelectBoy()
    {
        isBoy = true;
        SceneManager.LoadScene(2);
    }

    public void SelectGirl()
    {
        isBoy = false;
        SceneManager.LoadScene(2);
    }
}

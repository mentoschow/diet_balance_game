using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleBackButton : MonoBehaviour
{
    //BackButton
    public void OnClickTitleBackButton()
    {
        SceneManager.LoadScene(0);  
    }
}

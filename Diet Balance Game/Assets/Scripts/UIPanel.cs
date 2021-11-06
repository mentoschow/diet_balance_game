using UnityEngine;
using UnityEngine.UI;

public class UIPanel : MonoBehaviour
{
    public Image mainCharacter;
    public Image contentBg;
    public Text contentText;

    public void ShowMainCharacter(bool value)
    {
        mainCharacter.enabled = value;
    }

    public void ShowContentBg(bool value)
    {
        contentBg.enabled = value;
    }

    public void ShowContentText(bool value)
    {
        contentText.enabled = value;
    }

    public void SetContentText(string value)
    {
        contentText.text = value;
    }
}

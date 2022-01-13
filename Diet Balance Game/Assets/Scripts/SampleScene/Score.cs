using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;    //UI�̒ǉ�

public class Score : MonoBehaviour
{
    public bool next = false;
    public bool foodbookFlag = false;

    public PlayerManager pm;
    public Performance p;
    public AssetConfig character;

    [SerializeField] Image PlayerImg = null;      //�v���C���[�摜

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //�v���C���[�摜�̕\��
        if (pm.isboy == true)
        {
            PlayerImg.sprite = character.sprites[0];
        }
        else
        {
            PlayerImg.sprite = character.sprites[1];
        }
    }
}

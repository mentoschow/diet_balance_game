using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;    //UI�̒ǉ�

public class PlayerStatus : MonoBehaviour
{
    public bool next;           //�V�[���J�ڗp�̃u�[���ϐ�
    public PlayerManager pm;
    public Performance p;
    public AssetConfig character;
    public AssetConfig popup;
    public AssetConfig word;

    [SerializeField] Image PlayerImg = null;      //�v���C���[�摜
    [SerializeField] Image PopImg = null;         //�����o���摜 

    [SerializeField] Image Word1;       //����1
    [SerializeField] Image Word2;       //����2
    [SerializeField] Image Word3;       //����3

    int status;

    


    // Start is called before the first frame update
    void Start()
    {
        Random.InitState(System.DateTime.Now.Millisecond);  //���Ԃɂ�闐��������
        pm.hero.statusid = Random.Range(0, 5);
        status = pm.hero.statusid;      //�v���C���[�̃X�e�[�^�XID
        Debug.Log("PS" + status);
    }

    // Update is called once per frame
    void Update()
    {
        //�v���C���[�摜�̕\��
        if (pm.isboy == true)
        {
            PlayerImg.sprite = character.sprites[status * 2];
        }
        else
        {
            PlayerImg.sprite = character.sprites[status * 2 + 1];
        }

        //Pop�摜�̕\��
        PopImg.sprite = popup.sprites[status];

        //�����摜�̕\��
        if (status == 0)
        {
            //�u���ʁv
            Word1.sprite = word.sprites[0];
            Word2.sprite = word.sprites[1];
        }
        else if (status == 1)
        {
            //�u���ׁv
            Word1.sprite = word.sprites[2];
            Word2.sprite = word.sprites[3];
        }
        else if (status == 2)
        {
            //�u�Z�����v
            Word1.sprite = word.sprites[4];
            Word2.sprite = word.sprites[5];
            Word3.sprite = word.sprites[6];
        }
        else if (status == 3)
        {
            //�u�얞�v
            Word1.sprite = word.sprites[7];
            Word2.sprite = word.sprites[8];
        }
        else if (status == 4)
        {
            //�u���r��v
            Word1.sprite = word.sprites[9];
            Word2.sprite = word.sprites[10];
            Word3.sprite = word.sprites[11];
        }

        if (p.next)
        {
            if(Input.GetMouseButtonDown(0))
            {
                next = true;
            }
        }
        
    }
}

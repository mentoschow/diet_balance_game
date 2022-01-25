using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioChange : MonoBehaviour
{
    //AudoClip�̔z��Aclips��錾���܂��B
    public AudioClip[] clips;
    //AudioSource�^�̕ϐ�audios��錾���܂��B
    AudioSource audios;

    public Canvas selectCharacter;
    public SelectCharacter sc;
    public Canvas age_input;
    public Age_input ai;
    public Canvas performance;
    public Performance p;
    public Canvas Score;
    public Score score;
    public Canvas playerStatus;
    public PlayerStatus ps;
    public Canvas foodSelection;
    public FoodSelection fs;
    public Canvas enemyEncount;
    public EnemyEncount ee;
    public Canvas Battle;
    public BattleManager bm;
    public Canvas canvasResult;
    public Result result;
    public Canvas daydisplay;
    public DayDisplay dd;
    public Canvas foodbook;

    bool BGM = false;
    bool encountBGM = false;
    bool encount2BGM = false;
    bool daydisplay2BGM = false;
    bool selectBGM = false;
    bool battleBGM = false;
    bool daydisplayBGM = false;
    bool ResultBGM = false;
    void Start()
    {
        //GetComponennto��AudioSource�R���|�[�l���g�ɃA�N�Z�X����
        //�ϐ�audios�ŎQ�Ƃ��܂��B
        audios = GetComponent<AudioSource>();

        audios.clip = clips[0];
        audios.Play();
    }

    void Update()
    {
 
        if (score.next)//playerStatus
        {
            if (!encountBGM)
            {
                encountBGM = true;
                audios.clip = clips[1];
                audios.Play();
            }
        }
        if (ps.next)//enemyEncount
        {
            
            if (!encount2BGM)
            {
                encount2BGM = true;
                audios.clip = clips[2];
                audios.Play();
            }
        }
        if (ee.next)//foodSelection
        {
            if (!selectBGM)
            {
                selectBGM = true;
                audios.clip = clips[0];
                audios.Play();
            }
        }
        if (fs.next)//Battle
        {
            if (!battleBGM)
            {
                battleBGM = true;
                audios.clip = clips[2];
                audios.Play();
            }
        }
        if (bm.goawayNext)//daydisplay
        {
            if (!daydisplayBGM)
            {
                daydisplayBGM = true;
                audios.clip = clips[1];
                audios.Play();
            }
        }

        if (bm.next)//canvasResult
        {
            
            if (!ResultBGM)
            {
                ResultBGM = true;
                audios.clip = clips[1];
                audios.Play();
            }
        }
        if (result.next)//daydisplay
        {
            
            if (!daydisplay2BGM)
            {
                daydisplay2BGM = true;
                audios.clip = clips[1];
                audios.Play();
            }
        }
        if (dd.next)//playerStatus
        {
            
            if (!BGM)
            {
                BGM = true;
                audios.clip = clips[0];
                audios.Play();
            }

            encountBGM = false;
            encount2BGM = false;
            daydisplayBGM = false;
            ResultBGM = false;
            daydisplay2BGM = false;
            selectBGM = false;
            battleBGM = false;
            BGM = false;
        }
    }


}

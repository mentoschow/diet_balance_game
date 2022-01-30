using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioChange : CanvasManager
{
    public AudioClip[] clips;
    AudioSource audios;

    public Canvas gameover;

    bool BGM = false;
    bool encountBGM = false;
    bool encount2BGM = false;
    bool daydisplay2BGM = false;
    bool selectBGM = false;
    bool battleBGM = false;
    bool daydisplayBGM = false;
    bool winBGM = false;
    bool loseBGM = false;
    bool gameoverBGM = false;

    bool newgame = false; 

    void Start()
    {
        audios = GetComponent<AudioSource>();

        //audios.clip = clips[0];
        //audios.Play();
        //BGM = true;
    }

    void Update()
    {
        if(selectCharacter.enabled == true || Score.enabled == true)
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
            winBGM = false;
            daydisplay2BGM = false;
            selectBGM = false;
            battleBGM = false;
            loseBGM = false;
            gameoverBGM = false;
        }
            
        if (playerStatus.enabled == true)//playerStatus
        {
            if (!encountBGM)
            {
                encountBGM = true;
                audios.clip = clips[1];
                audios.Play();

                daydisplay2BGM = false;

            }
        }
        if (enemyEncount.enabled == true)//enemyEncount
        {
            
            if (!encount2BGM)
            {
                encount2BGM = true;
                audios.clip = clips[2];
                audios.Play();
            }
        }
        if (foodSelection.enabled == true)//foodSelection
        {
            if (!selectBGM)
            {
                selectBGM = true;
                audios.clip = clips[0];
                audios.Play();
            }
        }
        if (Battle.enabled == true)//Battle
        {
            if (!battleBGM)
            {
                battleBGM = true;
                audios.clip = clips[2];
                audios.Play();
            }
        }
        if (daydisplay.enabled == true)//daydisplay
        {
            if (!daydisplayBGM)
            {
                daydisplayBGM = true;
                audios.clip = clips[4];
                audios.Play();
            }
        }

        if (canvasResult.enabled == true)//canvasResult
        {
            if (bm.battle_result == true)
            {
                if (!winBGM)
                {
                    winBGM = true;
                    audios.clip = clips[3];
                    audios.Play();
                }
            }
            else
            {
                if (!loseBGM)
                {
                    loseBGM = true;
                    audios.clip = clips[5];
                    audios.Play();
                }
                if (gameover.enabled == true)
                {
                    if (!gameoverBGM)
                    {
                        gameoverBGM = true;
                        audios.clip = clips[6];
                        audios.Play();
                        //newgame = true;
                        BGM = false;
                    }
                    
                }
            }
        }
        if (daydisplay.enabled == true)//daydisplay
        {
            
            if (!daydisplay2BGM)
            {
                daydisplay2BGM = true;
                audios.clip = clips[4];
                audios.Play();

                encountBGM = false;
                encount2BGM = false;
                daydisplayBGM = false;
                winBGM = false;
                selectBGM = false;
                battleBGM = false;
                loseBGM = false;
                gameoverBGM = false;
            }
        }
        /*
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
            winBGM = false;
            daydisplay2BGM = false;
            selectBGM = false;
            battleBGM = false;
            BGM = false;
            loseBGM = false;
            gameoverBGM = false;
        }
        if (go.newgameFlag)
        {
            if (newgame == true)
            {
                newgame = false;
                encountBGM = false;
                encount2BGM = false;
                daydisplayBGM = false;
                winBGM = false;
                daydisplay2BGM = false;
                selectBGM = false;
                battleBGM = false;
                BGM = false;
                loseBGM = false;
            }
            
        }
        */
    }


}

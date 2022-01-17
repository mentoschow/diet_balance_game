using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
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

    void Start()
    {
        selectCharacter.enabled = true;
        age_input.enabled = false;
        performance.enabled = false;
        Score.enabled = false;
        playerStatus.enabled = false;
        foodSelection.enabled = false;
        enemyEncount.enabled = false;
        Battle.enabled = false;
        canvasResult.enabled = false;
        daydisplay.enabled = false;

        foodbook.enabled = false;
    }

    void Update()
    {
        if (sc.next)
        {
            selectCharacter.enabled = false;
            age_input.enabled = true;
        }
        if(ai.next)
        {
            age_input.enabled = false;
            performance.enabled = true;
        }

        if (p.next)
        {
            performance.enabled = false;
            if (score.foodbookFlag)
            {
                Score.enabled = false;
                foodbook.enabled = true;
            }
            else
            {
                foodbook.enabled = false;
                Score.enabled = true;
            }    
        }
        if (score.next)
        {
            Score.enabled = false;
            playerStatus.enabled = true;
        }
        if (ps.next)
        {
            playerStatus.enabled = false;
            foodSelection.enabled = true;
        }
        if (fs.next)
        {
            foodSelection.enabled = false;
            enemyEncount.enabled = true;
        }
        if (ee.next)
        {
            enemyEncount.enabled = false;
            Battle.enabled = true;
        }
        if (bm.next)
        {
            Battle.enabled = false;
            canvasResult.enabled = true;
        }
        if (result.next)
        {
            canvasResult.enabled = false;
            daydisplay.enabled = true;
        }
        if (dd.next)
        {
            daydisplay.enabled = false;
            playerStatus.enabled = true;

            ps.next = false;
            fs.next = false;
            ee.next = false;
            bm.next = false;
            result.next = false;
            dd.next = false;
        }
    }
}

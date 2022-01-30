using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public bool newgameFlag;

    public PlayerManager pm;
    public Canvas Score;
    public Score score;
    public PlayerStatus ps;
    public FoodSelection fs;
    public EnemyEncount ee;
    public BattleManager bm;
    public Result result;
    public DayDisplay dd;

    public AssetConfig character;
    [SerializeField] Image ChImg = null;

    // Start is called before the first frame update
    void Start()
    {
        newgameFlag = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(result.gameoverFlag)
        {
            if(pm.isboy)
            {
                ChImg.sprite = character.sprites[10];
            }
            else
            {
                ChImg.sprite = character.sprites[11];
            }
            

            if (Input.GetMouseButtonDown(0))
            {
                Score.enabled = true;

                score.next = false;
                ps.next = false;
                fs.next = false;
                ee.next = false;
                bm.next = false;
                bm.goawayNext = false;
                result.next = false;
                dd.next = false;

                result.gameoverFlag = false;
                newgameFlag = true;
            }
        }
    }
}

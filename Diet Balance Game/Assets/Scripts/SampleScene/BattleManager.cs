using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{
    public bool next = false;

    public EnemyManager em;  //enemy data
    public PlayerManager pm;  //player data
    public EnemyEncount ee;

    public AssetConfig enem;
    public AssetConfig character;

    public Image hero;
    public Image enemy;

    void Start()
    {
        //LoadCharacter(character.sprites[0], character.sprites[1]);  //LoadCharacter and LoadEnemy should be runed in Update because the character would be changed in SelectCharacter.
        //LoadEnemy(em.enemy.enemImgAddress);
        //Debug.Log(em.enemy.name);
    }

    void Update()
    {
        if (ee.next)
        {
            LoadCharacter(pm.hero.statusid); 
            LoadEnemy(em.enemy.enemID);
            //Debug.Log(em.enemy.name);
        }
    }

    void Battle()
    {
        //IDから敵の情報読み込み
        //int enemyID = enem_id;
        //string name = enemyData[enem_id][1];
        //string address = enemyData[enem_id][2];
        //int energy = int.Parse(enemyData[enem_id][3]);
        //float carb = float.Parse(enemyData[enem_id][4]);
        //float lipid = float.Parse(enemyData[enem_id][5]);
        //float protein = float.Parse(enemyData[enem_id][6]);
        //float vitamin = float.Parse(enemyData[enem_id][7]);
        //float mineral = float.Parse(enemyData[enem_id][8]);
    }

    void LoadCharacter(int status)
    {
        //プレイヤー画像の表示
        if (pm.isboy == true)
        {
            hero.sprite = character.sprites[status * 2];
        }
        else
        {
            hero.sprite = character.sprites[status * 2 + 1];
        }
    }

    void LoadEnemy(int status)
    {
        //Debug.Log("enemAddress: "+enemAddress);
        enemy.sprite = enem.sprites[status];
    }
}

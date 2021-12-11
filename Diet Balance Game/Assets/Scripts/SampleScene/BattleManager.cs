using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{
    public EnemyManager em;  //enemy data
    public PlayerManager pm;  //player data
    public FoodSelection fs;
    public AssetConfig enemy_sprite;
    public AssetConfig character;
    public Image hero;
    public Image enemy;

    void Start()
    {
        //LoadCharacter(character.sprites[0], character.sprites[1]);
        //LoadEnemy(enemy_sprite.sprites[0]);
    }

    void Update()
    {
        if (fs.next)
        {

        }
    }

    void Battle()
    {

    }

    void LoadCharacter(Sprite boy, Sprite girl)
    {
        if (pm.isboy)
        {
            hero.sprite = boy;
        }
        else
        {
            hero.sprite = girl;
        }
    }

    void LoadEnemy(Sprite tempSprite)
    {
        enemy.sprite = tempSprite;
    }
}

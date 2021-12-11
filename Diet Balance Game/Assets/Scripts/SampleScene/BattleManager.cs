using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{
    public EnemyManager em;
    public PlayerManager pm;
    public FoodSelection fs;
    public AssetConfig enemy_sprite;
    public AssetConfig character;
    public Image hero;

    void Start()
    {
        LoadCharacter(character.sprites[0], character.sprites[1]);
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
        if (pm.hero.isboy)
        {
            hero.sprite = boy;
        }
        else
        {
            hero.sprite = girl;
        }
    }

    void LoadEnemy()
    {

    }
}

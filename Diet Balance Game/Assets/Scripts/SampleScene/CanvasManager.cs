using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    public Canvas selectCharacter;
    public SelectCharacter sc;
    public Canvas performance;
    public Performance p;
    public Canvas foodSelection;
    public FoodSelection fs;
    public Canvas Battle;
    public BattleManager bm;

    void Start()
    {
        selectCharacter.enabled = true;
        performance.enabled = false;
        foodSelection.enabled = false;
        Battle.enabled = false;
    }

    void Update()
    {
        if (sc.next)
        {
            selectCharacter.enabled = false;
            performance.enabled = true;
        }
        if (p.next)
        {
            performance.enabled = false;
            foodSelection.enabled = true;
        }
        if (fs.next)
        {
            foodSelection.enabled = false;
            Battle.enabled = true;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleMng : MonoBehaviour
{
    public EnemyEncount ee;
    //変数の定義
    public ParticleSystem particle;

    // Start is called before the first frame update
    void Start()
    {
        //Particleシステムの取得（子オブジェクトから）
    }

    // Update is called once per frame
    void Update()
    {
        if (ee.next)
        {
            //particleSystem.Play();
        }
        
    }
}

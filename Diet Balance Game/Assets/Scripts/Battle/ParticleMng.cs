using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleMng : MonoBehaviour
{
    public EnemyEncount ee;
    //�ϐ��̒�`
    public ParticleSystem particle;

    // Start is called before the first frame update
    void Start()
    {
        //Particle�V�X�e���̎擾�i�q�I�u�W�F�N�g����j
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

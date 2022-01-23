using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemImgMng : MonoBehaviour
{
    public bool end_enem_down = false;           //�V�[���J�ڗp�̃u�[���ϐ�

    public EnemyEncount ee;

    //�n�_�C�I�_
    Vector3 startPos;
    Vector3 endPos;

    //���݂̈ʒu
    Vector3 present_pos;

    // �X�s�[�h
    public float speed = 1.0F;

    //��_�Ԃ̋���
    private float distance_two;

    float time_counter = 0;


    // Start is called before the first frame update
    void Start()
    {
        startPos = new Vector3(640, 980, 0);
        endPos = new Vector3(640, 360, 0);
        present_pos = startPos;
        distance_two = Vector3.Distance(startPos, endPos);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(transform.position);
        if (ee.run_update && end_enem_down == false)
        {
            time_counter += Time.deltaTime;
            // ���݂̈ʒu
            float present_Location = time_counter * speed / distance_two;
            
            // �I�u�W�F�N�g�̈ړ�
            transform.position = Vector3.Lerp(startPos, endPos, present_Location);
            present_pos = Vector3.Lerp(startPos, endPos, present_Location);
            
            if (present_pos == endPos)
            {
                end_enem_down = true;
            }
        }
        
    }

    public void Initilized_EnemImgMng()
    {
        time_counter = 0;

        transform.position = startPos;
        present_pos = startPos;
        distance_two = Vector3.Distance(startPos, endPos);

        end_enem_down = false;
    }
}

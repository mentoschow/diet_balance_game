using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemImgMng : MonoBehaviour
{
    public FoodSelection fs;

    //�n�_�C�I�_
    Vector3 startPos;
    Vector3 endPos;

    // �X�s�[�h
    public float speed = 1.0F;

    //��_�Ԃ̋���
    private float distance_two;


    // Start is called before the first frame update
    void Start()
    {
        startPos = new Vector3(640, 1500, 0);
        endPos = new Vector3(640, 360, 0);
        distance_two = Vector3.Distance(startPos, endPos);
    }

    // Update is called once per frame
    void Update()
    {
        if (fs.next)
        {
            // ���݂̈ʒu
            float present_Location = (Time.time * speed * 70) / distance_two;
            //Debug.Log(present_Location);
            // �I�u�W�F�N�g�̈ړ�
            transform.position = Vector3.Lerp(startPos, endPos, present_Location);
        }
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemImgMng : MonoBehaviour
{
    public bool end_enem_down = false;           //シーン遷移用のブール変数

    public FoodSelection fs;

    //始点，終点
    Vector3 startPos;
    Vector3 endPos;

    //現在の位置
    Vector3 present_pos;

    // スピード
    public float speed = 1.0F;

    //二点間の距離
    private float distance_two;


    // Start is called before the first frame update
    void Start()
    {
        startPos = new Vector3(640, 2000, 0);
        endPos = new Vector3(640, 360, 0);
        present_pos = startPos;
        distance_two = Vector3.Distance(startPos, endPos);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(transform.position);
        if (fs.next && end_enem_down == false)
        {
            // 現在の位置
            float present_Location = (Time.time * speed) * 100 / distance_two;
            
            // オブジェクトの移動
            transform.position = Vector3.Lerp(startPos, endPos, present_Location);
            present_pos = Vector3.Lerp(startPos, endPos, present_Location);
            
            if (present_pos == endPos)
            {
                end_enem_down = true;
            }
        }
        
    }
}

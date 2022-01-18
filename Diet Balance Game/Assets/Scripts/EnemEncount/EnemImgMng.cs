using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemImgMng : MonoBehaviour
{
    public bool end_enem_down = false;           //シーン遷移用のブール変数

    public EnemyEncount ee;
    [SerializeField] Image Pentagon = null;      //五角形画像

    //始点，終点
    Vector3 startPos;
    Vector3 endPos;

    //現在の位置
    Vector3 present_pos;

    // スピード
    public float speed = 1.0F;

    //二点間の距離
    private float distance_two;

    float time_counter = 0;


    // Start is called before the first frame update
    void Start()
    {
        startPos = new Vector3(640, 980, 0);
        endPos = new Vector3(640, 360, 0);
        present_pos = startPos;
        distance_two = Vector3.Distance(startPos, endPos);

        Pentagon.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(transform.position);
        if (ee.run_update && end_enem_down == false)
        {
            time_counter += Time.deltaTime;
            // 現在の位置
            float present_Location = time_counter * speed / distance_two;
            
            // オブジェクトの移動
            transform.position = Vector3.Lerp(startPos, endPos, present_Location);
            present_pos = Vector3.Lerp(startPos, endPos, present_Location);
            
            if (present_pos == endPos)
            {
                end_enem_down = true;
                Pentagon.enabled = true;
            }
        }
        
    }

    public void Initilized_EnemImgMng()
    {
        time_counter = 0;

        present_pos = startPos;
        distance_two = Vector3.Distance(startPos, endPos);

        end_enem_down = false;
        Pentagon.enabled = false;

        Debug.Log(present_pos);
    }
}

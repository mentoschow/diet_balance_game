using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class FoodData : ScriptableObject
{
    public List<Food> food;

    [System.Serializable]
    public class Food
    {
        public string name;     //�H�ו���
        public int energy;      //�G�l���M�[
        public float carb;      //�Y�������i�����j
        public float lipid;     //����
        public float protein;   //�^���p�N��
        public float vitamin;   //�r�^�~��  
        public float mineral;   //�~�l����
    }
}

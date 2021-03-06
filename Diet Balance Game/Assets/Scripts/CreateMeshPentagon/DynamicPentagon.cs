using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasRenderer))]
[RequireComponent(typeof(RectTransform))]
[ExecuteInEditMode]
public class DynamicPentagon : Graphic
{
    protected virtual void Awake()
    {
        base.Awake();

        // 横に合わせる
        maxRadius = rectTransform.rect.width / 2.0f;
        deltaTheta = 360.0f / getVertexCount();
        v = UIVertex.simpleVert;
    }

    protected virtual void Update()
    {
//#if UNITY_EDITOR
        yRate = rectTransform.rect.height / rectTransform.rect.width;
        maxRadius = rectTransform.rect.width / 2.0f;
        deltaTheta = 360.0f / getVertexCount();

        this.UpdateGeometry();
//#endif
    }

    public void SetUp()
    {
        yRate = rectTransform.rect.height / rectTransform.rect.width;
        maxRadius = rectTransform.rect.width / 2.0f;
        deltaTheta = 360.0f / getVertexCount();

        this.UpdateGeometry();
    }

    protected override void OnPopulateMesh(VertexHelper vh)
    {
        // 初期化
        vh.Clear();

        // 点の計算
        for (int i = 0; i < getVertexCount(); i++)
        {
            tempVector.x = maxRadius * getVertexRate(i) * Mathf.Sin(Mathf.Deg2Rad * i * deltaTheta);
            tempVector.y = yRate * maxRadius * getVertexRate(i) * Mathf.Cos(Mathf.Deg2Rad * i * deltaTheta);
            v.color = pentagonBackgroundColor;
            v.position = tempVector;
            vh.AddVert(v);
        }

        // 中心
        v.position = Vector3.zero;
        vh.AddVert(v);

        // index生成
        for (int i = 0; i < getVertexCount(); i++)
        {
            vh.AddTriangle(
                i,
                (i + 1) % getVertexCount(),
                getVertexCount()
            );
        }
    }

    protected virtual float getVertexRate(int index)
    {
        return 1.0f;
    }

    protected virtual int getVertexCount()
    {
        return 3;
    }

    // 最大半径(Rect.widthの半分)
    private float maxRadius;
    private float deltaTheta;
    private Vector3 tempVector;
    private UIVertex v;
    private float yRate;

    [SerializeField]
    private Color32 pentagonBackgroundColor = Color.red;
}

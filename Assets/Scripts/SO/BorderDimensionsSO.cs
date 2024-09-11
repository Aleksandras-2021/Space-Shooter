using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BorderDimensionsSO", menuName = "CreateBorderDimensionsSO")]

public class BorderDimensionsSO : ScriptableObject
{
    [SerializeField]
    private float borderRight = 11f;
    [SerializeField]
    private float borderLeft = -11f;
    [SerializeField]
    private float borderTop = 3.30f;
    [SerializeField]
    private float borderBottom = -2.10f;
    public float borderRightProperty => borderRight;
    public float borderLeftProperty => borderLeft;
    public float borderTopProperty => borderTop;
    public float borderBottomProperty => borderBottom;

}

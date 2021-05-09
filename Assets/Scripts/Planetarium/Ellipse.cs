using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Ellipse : MonoBehaviour
{
    public float xAxis;
    public float zAxis;

    public Ellipse (float xAxis, float zAxis)
    {
        this.xAxis = xAxis;
        this.zAxis = zAxis;
    }

    public Vector2 Evaluate(double t)
    {
        float angle = Mathf.Deg2Rad * 360f * (float)t;
        float x = Mathf.Sin(angle) * xAxis;
        float z = Mathf.Cos(angle) * zAxis;
        return new Vector2(x, z);
    }

    public Vector2 EvaluatePath (double t)
    {
        float angle =  Mathf.Deg2Rad * (float) t;
        float x = Mathf.Sin(angle) * xAxis;
        float z = Mathf.Cos(angle) * zAxis;
        return new Vector2(x, z);
    }
}

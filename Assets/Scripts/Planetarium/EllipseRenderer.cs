using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EllipseRenderer : MonoBehaviour
{
    public LineRenderer lr;

    public int segments;
    public Ellipse ellipse;
    public GameObject Sun;

    private void Awake()
    {
        lr = GetComponent<LineRenderer>();
        CalculateEllipse();
    }

    void CalculateEllipse()
    {
        Vector3[] points = new Vector3[segments + 1];
        for (int i = 0; i < segments; i++)
        {
            Vector2 position2D = ellipse.Evaluate((float)i / (float)segments);
            points[i] = new Vector3(position2D.x + Sun.transform.position.x, Sun.transform.position.y, position2D.y + Sun.transform.position.z);
        }
        points[segments] = points[0];

        lr.positionCount = segments + 1;
        lr.SetPositions(points);
    }

    public Vector2 getEvaluatedEllipse(double t)
    {
        Vector2 position2D = ellipse.EvaluatePath(t);
        position2D = new Vector2(position2D.x+Sun.transform.position.x, position2D.y+Sun.transform.position.z);
        return position2D;
    }

    public Vector2 getEvaluatedEllipseMoon(double t, Vector3 orbitalPos)
    {
        Vector2 position2D = ellipse.EvaluatePath(t);
        position2D = new Vector2(position2D.x + orbitalPos.x, position2D.y + orbitalPos.z);
        return position2D;
    }

    private void OnValidate()
    {
        CalculateEllipse();
    }

    private void Update()
    {
        CalculateEllipse();
    }
}

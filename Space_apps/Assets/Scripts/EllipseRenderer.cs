using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EllipseRenderer : MonoBehaviour
{
    LineRenderer lr;

    [Range(3, 36)]
    public int segments;
    public Ellipse ellipse;

    void Awake()
    {
        lr = GetComponent<LineRenderer>();
        CalculateEllipse();
    }
    void CalculateEllipse()
    {
        Vector3[] points = new Vector3[segments + 1];
        for (int i = 0; i < segments; i++)
        {
            Vector2 point = ellipse.Evaluate((float)i / (float)segments);
            points[i] = new Vector3(point.x, point.y, 0);
        }
        points[segments] = points[0];

        lr.positionCount = segments + 1;
        lr.SetPositions(points);
    }

    void OnValidate()
    {
        if (Application.isPlaying && lr)
            CalculateEllipse();
    }

}

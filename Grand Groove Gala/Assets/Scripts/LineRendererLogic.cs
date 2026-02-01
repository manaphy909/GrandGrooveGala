using UnityEngine;
using System.Collections.Generic;

public class LineRendererLogic : MonoBehaviour
{
    private LineRenderer lineRenderer;

    public List<Vector3> points;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }
    public void DrawLineFromPoints()
    {
        lineRenderer.positionCount = points.Count;

        lineRenderer.SetPositions(points.ToArray());

        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;
        lineRenderer.startColor = Color.blue;
        lineRenderer.endColor = Color.cyan;
    }
}

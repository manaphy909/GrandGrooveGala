using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class TargetCircle : MonoBehaviour
{
    public Light spotLight;
    public FieldOfView fieldOfView;
    public LineRendererLogic lineRendererLogic;

    public List<Vector3> pathPoints;
    public float moveSpeed = 5f;
    public float reachDistance = 0.1f;

    private int currentIndex = 0;

    private void Start()
    {
        pathPoints = lineRendererLogic.points;
    }

    void UpdatePosition()
    {
        if (pathPoints == null || pathPoints.Count == 0) return;
        if (currentIndex >= pathPoints.Count) return;

        Vector3 target = pathPoints[currentIndex];

        transform.position = Vector3.MoveTowards(
            transform.position,
            target,
            moveSpeed * Time.deltaTime
        );

        if (Vector3.Distance(transform.position, target) <= reachDistance)
        {
            currentIndex++;
        }
    }

    void UpdateScale()
    {
        transform.localScale = new Vector3(3.59f - fieldOfView.suspicion, -0.09f, 3.59f - fieldOfView.suspicion);
        spotLight.spotAngle -= fieldOfView.suspicion / 35f;
    }

    void Update()
    {
        UpdatePosition();
        if (transform.localScale.x > 0) UpdateScale();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "Player") Debug.Log("hit player");

    }
}

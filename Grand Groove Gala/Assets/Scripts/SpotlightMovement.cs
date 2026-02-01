using UnityEngine;

public class SpotlightMovement : MonoBehaviour
{
    public GameObject spotlightTarget;
    void Update()
    {
        transform.LookAt(spotlightTarget.transform.position);
    }
}

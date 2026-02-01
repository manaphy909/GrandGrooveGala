using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public GameObject target;

    public FollowCamera(GameObject target)
    {
        this.target = target;
    }

    private void Start()
    {
        target = GameObject.FindWithTag("MainCamera");
    }

    private void Update()
    {
        Vector3 targetPosition = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);

        transform.LookAt(targetPosition);

        transform.rotation.Set(0.0f, transform.rotation.y + 0.0f, 0.0f, transform.rotation.w);
    }
}

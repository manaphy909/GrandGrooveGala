using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class TargetCircle : MonoBehaviour
{
    public SpotLight spotLight;
    public FieldOfView fieldOfView;
    public Vector3 scale;

    void ChangeScale()
    {
        scale.x = 3.59f - fieldOfView.suspicion;
        scale.z = 3.59f - fieldOfView.suspicion;

    }
    void Update()
    {
        ChangeScale();
        transform.localScale = scale;
    }
}

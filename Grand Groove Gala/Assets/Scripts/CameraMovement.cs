using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform player;
    public float x;
    public float y;
    public float z;
    // Update is called once per frame
    void Update()
    {
        Vector3 cameraPosOffset = new Vector3 (x, y, z);
        //Vector3 cameraRotOffset = new Vector3 (20.901f, 143.078f, 0);

        transform.position = cameraPosOffset + player.transform.position;
    }
}

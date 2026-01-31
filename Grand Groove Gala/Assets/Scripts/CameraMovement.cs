using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform player;
    // Update is called once per frame
    void Update()
    {
        Vector3 cameraPosOffset = new Vector3 (-5.624367f, 3.267657f, 4.965053f);
        //Vector3 cameraRotOffset = new Vector3 (20.901f, 143.078f, 0);

        transform.position = cameraPosOffset + player.transform.position;
    }
}

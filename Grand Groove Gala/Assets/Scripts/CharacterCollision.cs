using Unity.VisualScripting;
using UnityEngine;

public class CharacterCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && gameObject.tag == "Target") collision.gameObject.GetComponent<PlayerMovementPrime>().hasKeyCard = true;
    }
}

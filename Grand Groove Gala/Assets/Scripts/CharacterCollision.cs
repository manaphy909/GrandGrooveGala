using Unity.VisualScripting;
using UnityEngine;

public class CharacterCollision : MonoBehaviour
{
    public GameObject twinkle;

    private void Start()
    {
        if (gameObject.tag != "Target")
        {
            twinkle.SetActive(false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && gameObject.tag == "Target")
        {
            collision.gameObject.GetComponent<PlayerMovementPrime>().hasKeyCard = true;
            twinkle.SetActive(false);
        }
    }


}

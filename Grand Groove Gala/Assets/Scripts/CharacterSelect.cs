using UnityEngine;

public class CharacterSelect : MonoBehaviour
{
    public SpriteRenderer charactersprite;
    public Sprite[] characters;

    private void Start()
    {
        int roll = UnityEngine.Random.Range(0, 2);

        if (roll == 1 )
        {
            charactersprite.sprite = characters[0];
        }
        else
        {
            charactersprite.sprite = characters[1];
        }
    }
}

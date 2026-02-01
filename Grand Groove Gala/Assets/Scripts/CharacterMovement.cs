using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public GameObject[] tiles;
    
    /*private int[] CheckDirections(TileData curTile)
    {
        int x = curTile.x;
        int y = curTile.y;


    }*/

    private void Start()
    {
        Debug.Log("start character movement");
        tiles = GetComponent<InitializeObjects>().tiles;
    }

    public void UpdateCharacterMovement()
    {
        for (int i = 0; i < tiles.Length; i++)
        {
           
        }
    }
}

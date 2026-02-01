using UnityEngine;

public class TileData : MonoBehaviour
{
    public Vector2Int gridPos;
    public bool isOccupied;
    public GameObject currentOccupant;
    public bool hasSwapped;

    public int x;
    public int y;
    public CharacterData character;

    public TileData(Vector2Int pos)
    {
        gridPos = pos;
        isOccupied = false;
        currentOccupant = null;
        hasSwapped = false;
    }
}
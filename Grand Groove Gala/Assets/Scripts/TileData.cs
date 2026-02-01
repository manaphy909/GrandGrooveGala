using UnityEngine;

public class TileData
{
    public Vector2Int gridPos;
    public bool isOccupied;
    public GameObject currentOccupant;
    public bool hasSwapped;

    public TileData(Vector2Int pos)
    {
        gridPos = pos;
        isOccupied = false;
        currentOccupant = null;
        hasSwapped = false;
    }
}

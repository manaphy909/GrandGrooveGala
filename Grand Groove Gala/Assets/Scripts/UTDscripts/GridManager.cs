using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GridManager : MonoBehaviour
{
    public static GridManager Instance;
    public Tilemap groundTilemap;
    public Tilemap characterTilemap;
    private Dictionary<Vector2Int, TileData> tiles = new Dictionary<Vector2Int, TileData>();

    private void Awake()
    {
        Instance = this;
        GenerateGridData(groundTilemap);
        GenerateGridData(characterTilemap);
        Debug.Log(characterTilemap.size);
    }

    void GenerateGridData(Tilemap tilemap)
    {
        BoundsInt bounds = tilemap.cellBounds;

        foreach (Vector3Int tilePos in bounds.allPositionsWithin)
        {
            if (tilemap.HasTile(tilePos))
            {
                Vector2Int gridPos = new Vector2Int(tilePos.x, tilePos.y);
                tiles.Add(gridPos, new TileData(gridPos));
            }
        }
    }

    public TileData GetTileAt(Vector2Int gridPos)
    {
        tiles.TryGetValue(gridPos, out TileData tile);
        return tile;
    }

    public Vector3 GetWorldPosition(Vector2Int gridPos)
    {
        Vector3Int cell = new Vector3Int(gridPos.x, gridPos.y, 0);
        return groundTilemap.GetCellCenterWorld(cell);
    }
}
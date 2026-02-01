using UnityEngine;
using System.Collections;

public class GridCharacter : MonoBehaviour
{
    public Vector2Int gridPosition;
    public float moveSpeed = 5f;

    private bool isMoving = false;

    void Start()
    {
        OccupyTile(gridPosition);
        transform.position = GridManager.Instance.GetWorldPosition(gridPosition);
    }

    public void TryMove(Vector2Int direction)
    {
        if (isMoving) return;

        Vector2Int targetPos = gridPosition + direction;
        TileData targetTile = GridManager.Instance.GetTileAt(targetPos);

        if (targetTile == null) return;
        if (targetTile.isOccupied) return;

        StartCoroutine(MoveToTile(targetTile));
    }

    IEnumerator MoveToTile(TileData targetTile)
    {
        isMoving = true;

        TileData currentTile = GridManager.Instance.GetTileAt(gridPosition);
        currentTile.isOccupied = false;
        currentTile.currentOccupant = null;

        Vector3 start = transform.position;
        Vector3 end = GridManager.Instance.GetWorldPosition(targetTile.gridPos);

        float t = 0;
        while (t < 1)
        {
            t += Time.deltaTime * moveSpeed;
            transform.position = Vector3.Lerp(start, end, t);
            yield return null;
        }

        gridPosition = targetTile.gridPos;
        OccupyTile(gridPosition);

        isMoving = false;
    }

    void OccupyTile(Vector2Int pos)
    {
        TileData tile = GridManager.Instance.GetTileAt(pos);
        tile.isOccupied = true;
        tile.currentOccupant = gameObject;
    }
}

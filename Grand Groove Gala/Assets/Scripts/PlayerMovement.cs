using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int playerX;
    public int playerY;
    [SerializeField] float yOffset = 0.59f;

    private bool isMoving = false;
    private Vector3 targetPosition;
    private TileData targetTile;
    private float moveSpeed = 10f;


    public GameObject grid;
    private InitializeObjects gridData;
    public TileData currentTile;

    private GameObject[] invalidTilesList;
    public GameObject invalidTilesParent;

    public float timer = 0;

    bool TileExists(int x, int y)
    {
        invalidTilesList = new GameObject[invalidTilesParent.transform.childCount];
        foreach (Transform child in invalidTilesParent.transform)
        {
            if (x == child.GetComponent<TileData>().x &&
                y == child.GetComponent<TileData>().y &&
                child.gameObject.CompareTag("Undancable"))
            {
                Debug.Log("tile does NOT exist");
                return false;
            }
        }
        Debug.Log("tile does exist");
        return true;
    }

    void BeginMove()
    {
        isMoving = true;

        foreach (GameObject tileObj in gridData.tiles)
        {
            TileData tile = tileObj.GetComponent<TileData>();
            if (tile.x == playerX && tile.y == playerY)
            {
                targetTile = tile;

                targetPosition = new Vector3(
                    tileObj.transform.position.x,
                    tileObj.transform.position.y + yOffset,
                    tileObj.transform.position.z
                );

                CharacterData playerData = GetComponent<CharacterData>();
                CharacterData targetData = targetTile.character;

                if (targetData != null)
                    Debug.Log(playerData.name + " swaps with " + targetData.name);
                else
                    Debug.Log(playerData.name + " moves into empty tile");

                targetTile.character = playerData;
                currentTile.character = targetData;

                if (targetData != null)
                {
                    Vector3 temp = new Vector3 (currentTile.transform.position.x,
                                                currentTile.transform.position.y + yOffset,
                                                currentTile.transform.position.z);
                    targetData.transform.position = temp;
                        //Vector3.Lerp(targetData.transform.position, temp, Time.deltaTime * moveSpeed);
                }

                currentTile = targetTile;

                break;
            }
        }
    }



    void CheckMovement()
    {
        if (isMoving) return;
        if (timer < 1.5f) return;

        Vector2Int dir = Vector2Int.zero;

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) dir.x += 1;
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) dir.x -= 1;
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) dir.y += 1;
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) dir.y -= 1;

        if (dir == Vector2Int.zero) return;

        int nextX = playerX + dir.x;
        int nextY = playerY + dir.y;

        if (TileExists(nextX, nextY))
        {
            playerX = nextX;
            playerY = nextY;
            timer = 0;

            BeginMove();
        }
    }


    void ApplyMovement()
    {
        if (!isMoving) return;

        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * moveSpeed);

        if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
        {
            transform.position = targetPosition;
            isMoving = false;
        }
    }


    private void Start()
    {
        gridData = grid.GetComponent<InitializeObjects>();
    }

    void Update()
    {
        timer += Time.deltaTime;
        CheckMovement();
        ApplyMovement();
    }
}

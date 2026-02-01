using System;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.EventSystems;

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

    void BeginMove(Vector3 Direction)
    {

        if(CheckForWalls(Direction) == false)
        {

            return;

        }

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



    bool CheckForWalls(Vector3 Direction)
    {

        String targetTag = "Wall";

        RaycastHit hit;

        Debug.DrawRay(transform.position, Direction * 1f, Color.red, 1000);

        if (Physics.Raycast(transform.position, Direction * 1f, out hit))
        {

            if (hit.collider.CompareTag(targetTag))
            {

                Debug.Log("hit wall");
                return false;
            }
            else
            {

                return true;

            }

        }
        else
        {
            return true;
        }
        

        
    }




    void CheckMovement()
    {
        Vector3 Direction = Vector3.forward;

        if (isMoving) return;
        if (timer < 1.5f) return;

        Vector2Int dir = Vector2Int.zero;

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) { dir.x += 1; Direction = Vector3.back; }
        
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) { dir.x -= 1; Direction = Vector3.forward; }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) { dir.y += 1; Direction = Vector3.left; }
        
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {dir.y -= 1; Direction=Vector3.right; }
        

        if (dir == Vector2Int.zero) return;

        int nextX = playerX + dir.x;
        int nextY = playerY + dir.y;

        if (TileExists(nextX, nextY))
        {
            playerX = nextX;
            playerY = nextY;
            timer = 0;

            BeginMove(Direction);
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

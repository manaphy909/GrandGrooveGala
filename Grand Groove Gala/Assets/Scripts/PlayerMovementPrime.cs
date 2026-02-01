using System;
using System.Threading;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovementPrime : MonoBehaviour
{
    public int playerX;
    public int playerY;
    [SerializeField] float yOffset = 0.59f;

    private bool isMoving = false;
    private Vector3 targetPosition;
    private float moveSpeed = 10f;
    public bool CheckTileBool;
    public int PlayerActiveMask;

    public int nextX;
    public int nextY;

    private float StartDelay = 1.0f;
    public float RepeatDelay;



    public Vector2 Direction = Vector2.up;

    Vector2Int dir = Vector2Int.zero;

    public string DirectionToMoveX;
    public string DirectionToMoveY;

    public TileData currentTile;

    private HealthComponent health;

    private TileData targetTile;

    private PlayerIdentity PlayerMask;


    private InitializeObjects gridData;

    public GameObject grid;
    private GameObject[] invalidTilesList;
    public GameObject invalidTilesParent;

    public float timer;



    public void Start()
    {
        StartDelay = 3.0f;

        RepeatDelay = 3.0f;

        gridData = grid.GetComponent<InitializeObjects>();

        health = gameObject.GetComponent<HealthComponent>();

        PlayerMask = gameObject.GetComponent<PlayerIdentity>();

        timer = RepeatDelay;

        health.TimeBar.value = timer;

        InvokeRepeating("ConstantRun", StartDelay, RepeatDelay);

    }


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

    void BeginMove(Vector2 Direction)
    {

        nextX = playerX + dir.x;
        nextY = playerY + dir.y;

        if (TileExists(nextX, nextY) != false)
        {
            playerX = nextX;
            playerY = nextY;

            if (CheckForWalls(Direction) == false)
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
                        Vector3 temp = new Vector3(currentTile.transform.position.x,
                                                    currentTile.transform.position.y + yOffset,
                                                    currentTile.transform.position.z);
                        targetData.transform.position = temp;
                        //Vector3.Lerp(targetData.transform.position, temp, Time.deltaTime * moveSpeed);
                    }

                    currentTile = targetTile;

                    break;
                }
            }

            print("good");

            CheckTile();

            Reset();

            

            
        }
        else
        {
            print("bad");

            //playerX = playerX - dir.x; playerY = playerY - dir.y;

            Reset();
        }


        //grid.GetComponent<CharacterMovement>().UpdateCharacterMovement();
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
        //Vector3 Direction = Vector3.forward;

        if (isMoving) return;
        


        Vector2Int dir = Vector2Int.zero;


        if (Input.GetKeyDown(KeyCode.W)) { /*dir.x = 1;*/ DirectionToMoveX = "Up"; } //nextX = playerX + dir.x; } //Direction = Vector3.back; }

        if (Input.GetKeyDown(KeyCode.S)) { /*dir.x = -1;*/ DirectionToMoveX = "Down";} //nextX = playerX + dir.x; }//= Vector3.forward; }

        if (Input.GetKeyDown(KeyCode.D)) { /*dir.y = 1;*/ DirectionToMoveY = "Left"; }//nextY = playerY + dir.y; }

        if (Input.GetKeyDown(KeyCode.A)) { /*dir.y = -1;*/ DirectionToMoveY = "Right"; } //nextY = playerY + dir.y; }


        if (dir == Vector2Int.zero) return;


        //int nextX = playerX + dir.x;
        //int nextY = playerY + dir.y;
            

    }



    public void Reset()
    {
        nextX = playerX; nextY = playerY;

        DirectionToMoveX = "";
        DirectionToMoveY = "";
        dir.x = 0;
        dir.y = 0;
    }

    void CheckMaskChange()
    {
        if (Input.GetKey(KeyCode.UpArrow)) { PlayerMask.activeMask = 0; PlayerMask.SetActiveMask(); PlayerActiveMask = 0; }

        if (Input.GetKey(KeyCode.DownArrow)) { PlayerMask.activeMask = 1; PlayerMask.SetActiveMask(); PlayerActiveMask = 1; }

        if (Input.GetKey(KeyCode.LeftArrow)) { PlayerMask.activeMask = 2; PlayerMask.SetActiveMask(); PlayerActiveMask = 2; }

        if (Input.GetKey(KeyCode.RightArrow)) { PlayerMask.activeMask = 3; PlayerMask.SetActiveMask(); PlayerActiveMask = 3; }



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

        //CheckTile();

    }
    


  


    void ConstantRun()
    {

        switch (DirectionToMoveX)
        {
            case "Up":
                dir.x = 1;
                    break;

            case "Down":
                dir.x = -1;
                break;

        }

        switch (DirectionToMoveY)
        {
            case "Left":
                dir.y = 1;
                break;

            case "Right":
                dir.y = -1;
                break;

        }


        BeginMove(Direction);


    }


    void Update()
    {
        
        CheckMovement();
        ApplyMovement();
        CheckMaskChange();


        timer -= Time.deltaTime;

        health.TimeBar.value = MathF.Max(timer, 0);

        if(timer <= 0f)
        {
            timer = RepeatDelay;
        }

    }


    void CheckTile()
    {
        MaskTrackerComponent TileMask = targetTile.GetComponent<MaskTrackerComponent>();

        if (TileMask.activeMask != PlayerActiveMask)
        {

            health.TakeDamage(10);

        }

    }







}

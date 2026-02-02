using System;
using System.Threading;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovementPrime : MonoBehaviour
{
    public bool hasKeyCard = false;
    public float roundsInCircle;
    private LineRendererLogic lineRendererLogic;

    public GameObject keycardText;

    public int playerX;
    public int playerY;
    [SerializeField] float yOffset = 0.59f;

    private bool isMoving = false;
    private Vector3 targetPosition;
    private float moveSpeed = 10f;
    public bool CheckTileBool;

    public Mask PlayerActiveMask;

    public int nextX;
    public int nextY;

    private float StartDelay = 1.0f;
    public float RepeatDelay;



    public Vector2 Direction = Vector2.up;

    Vector2Int dir = Vector2Int.zero;

    public string DirectionToMoveX;
    public string DirectionToMoveY;

    public TileData currentTile;

    public HealthComponent health;

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


        //health = gameObject.GetComponent<HealthComponent>();

        gridData = grid.GetComponent<InitializeObjects>();

        PlayerMask = gameObject.GetComponent<PlayerIdentity>();

        lineRendererLogic = gameObject.GetComponent<LineRendererLogic>();

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

    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "VIPzone" && timer > 2.98)
        {
            roundsInCircle++;
            if (roundsInCircle == 10) hasKeyCard = true;
        }


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
                    if (tile.isDoor) SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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
                    }

                    currentTile = targetTile;

                    break;
                }
            }

            print("good");
            // increment roundsincircle if inside the circle

            CheckTile();

            Reset();

            

            
        }
        else
        {
            print("bad");

            //playerX = playerX - dir.x; playerY = playerY - dir.y;

            Reset();
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
        //Vector3 Direction = Vector3.forward;

        if (isMoving) return;
        


        Vector2Int dir = Vector2Int.zero;


        if (Input.GetKey(KeyCode.W)) { /*dir.x = 1;*/ DirectionToMoveX = "Up"; } //nextX = playerX + dir.x; } //Direction = Vector3.back; }

        if (Input.GetKey(KeyCode.S)) { /*dir.x = -1;*/ DirectionToMoveX = "Down";} //nextX = playerX + dir.x; }//= Vector3.forward; }

        if (Input.GetKey(KeyCode.D)) { /*dir.y = 1;*/ DirectionToMoveY = "Left"; }//nextY = playerY + dir.y; }

        if (Input.GetKey(KeyCode.A)) { /*dir.y = -1;*/ DirectionToMoveY = "Right"; } //nextY = playerY + dir.y; }


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
        if (Input.GetKeyDown(KeyCode.UpArrow)) 
        { 
            PlayerMask.activeMaskEnum = MaskTypes.Lust; 
            PlayerMask.SetActiveMask();
        }


        if (Input.GetKeyDown(KeyCode.DownArrow)) { PlayerMask.activeMaskEnum = MaskTypes.Sloth; PlayerMask.SetActiveMask();}

        if (Input.GetKeyDown(KeyCode.LeftArrow)) { PlayerMask.activeMaskEnum = MaskTypes.Coward; PlayerMask.SetActiveMask();}

        if (Input.GetKeyDown(KeyCode.RightArrow)) { PlayerMask.activeMaskEnum = MaskTypes.Wrath; PlayerMask.SetActiveMask();}

    }

    void ApplyMovement()
    {

        if (!isMoving) return;

        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * moveSpeed);

        if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
        {
            transform.position = targetPosition;
            isMoving = false;

            lineRendererLogic.points.Add(transform.position);
            lineRendererLogic.DrawLineFromPoints();
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

        if (hasKeyCard && !keycardText.activeSelf) keycardText.SetActive(true);

    }


    void CheckTile()
    {
        MaskTrackerComponent TileMask = targetTile.GetComponent<MaskTrackerComponent>();

        if (TileMask.activeMaskEnum != PlayerMask.activeMaskEnum)
        {

            health.TakeDamage(10);

        }

    }







}

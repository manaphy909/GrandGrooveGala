using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int playerX;
    public int playerY;
    public GameObject grid;

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
                child.gameObject.tag == "Undancable")
            {
                return false;
            }
        }
        return true;
    }

    void CheckMovement()
    {
        int nextX = playerX;
        int nextY = playerY;
        if (timer < 1.5f) return;
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) nextX++;
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) nextY--;
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) nextX--;
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) nextY++;
        if (playerX != nextX || playerY != nextY) timer = 0;

        if (TileExists(nextX, nextY))
        {
            playerX = nextX;
            playerY = nextY;
        }
    }

    void ApplyMovement()
    {

        int tileIndex = 0;
        for (int i = 0; i < grid.GetComponent<InitializeObjects>().tiles.Length; i++)
        {
            if (playerX == grid.GetComponent<InitializeObjects>().tiles[i].GetComponent<TileData>().x &&
                playerY == grid.GetComponent<InitializeObjects>().tiles[i].GetComponent<TileData>().y)
            {
                tileIndex = i; break;
            }
        }

        if (tileIndex != 0)
        {
            Vector3 newPos = new Vector3(grid.GetComponent<InitializeObjects>().tiles[tileIndex].transform.position.x,
                                         grid.GetComponent<InitializeObjects>().tiles[tileIndex].transform.position.y + transform.position.y,
                                         grid.GetComponent<InitializeObjects>().tiles[tileIndex].transform.position.z);
            transform.position = Vector3.Lerp(transform.position, newPos, .9f);
        }

    }

    void Update()
    {
        timer += Time.deltaTime;
        CheckMovement();
        ApplyMovement();
        Debug.Log(timer);
    }
}

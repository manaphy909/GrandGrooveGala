using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int playerX;
    public int playerY;
    public GameObject grid;

    private GameObject[] invalidTilesList;
    public GameObject invalidTilesParent;

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

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) nextX++;
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) nextY--;
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) nextX--;
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) nextY++;

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
            float x = grid.GetComponent<InitializeObjects>().tiles[tileIndex].transform.position.x;
            float y = grid.GetComponent<InitializeObjects>().tiles[tileIndex].transform.position.y;
            float z = grid.GetComponent<InitializeObjects>().tiles[tileIndex].transform.position.z;
            transform.position = new Vector3(x, y + transform.position.y, z);
            Debug.Log(playerX + ", " + playerY);
        }
    }

    void Update()
    {
        CheckMovement();
        ApplyMovement();
    }
}

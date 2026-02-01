using System;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;

public class PlayerMovement : MonoBehaviour
{
    public GridCharacter gridCharacter;
    public float timer = 0;

    void Update()
    {
        if (timer > 1.5f) return;
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            gridCharacter.TryMove(Vector2Int.down);
            timer = 0;
        }            
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            gridCharacter.TryMove(Vector2Int.up);
            timer = 0;
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            gridCharacter.TryMove(Vector2Int.right);
            timer = 0;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            gridCharacter.TryMove(Vector2Int.left);
            timer = 0;
        }
        timer += Time.deltaTime;
    }
}
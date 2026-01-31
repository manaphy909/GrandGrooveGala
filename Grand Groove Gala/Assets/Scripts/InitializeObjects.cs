using Mono.Cecil;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class InitializeObjects : MonoBehaviour
{
    public GameObject player;
    public GameObject[] tiles;
    public GameObject[] characters;

    void Start()
    {
        GameObject ground = transform.Find("Ground").gameObject;
        int i = 0;
        tiles = new GameObject[ground.transform.childCount];
        foreach (Transform child in ground.transform)
        {
            tiles[i] = child.gameObject;
            i++;
        }

        GameObject characterList = transform.Find("Characters").gameObject;
        i = 0;
        characters = new GameObject[characterList.transform.childCount];
        foreach (Transform child in characterList.transform)
        {
            child.gameObject.name = child.gameObject.name + i;
            characters[i] = child.gameObject;
            characters[i].GetComponent<CharacterData>().ID = i;
            tiles[i].GetComponent<TileData>().character = characters[i].GetComponent<CharacterData>();
            i++;
        }
        tiles[i].GetComponent<TileData>().character = player.GetComponent<CharacterData>();
        player.GetComponent<PlayerMovement>().currentTile = tiles[i].GetComponent<TileData>();
    }
}

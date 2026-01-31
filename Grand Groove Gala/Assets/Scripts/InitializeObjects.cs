using Mono.Cecil;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class InitializeObjects : MonoBehaviour
{
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
            characters[i] = child.gameObject;
            characters[i].GetComponent<CharacterData>().ID = i - 1;
            i++;
        }
    }
}

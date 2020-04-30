using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1Controller : MonoBehaviour
{
    public GameObject[] player1Spaces;
    public int spaceIndex;
    public bool canPlayCard;
    public int playerNumber;

    private GameObject[] GetGameSpaces()
    {
        GameObject[] spaces = new GameObject[9];

        for(int i = 0; i < 9; i++)
        {
            spaces[i] = GameObject.Find("BoardSpaces").GetComponent<Transform>().GetChild(i).gameObject;
        }
    
        return spaces;
    }

    
    // Start is called before the first frame update
    void Start()
    {
        player1Spaces = GetGameSpaces();
        spaceIndex = 0;
        canPlayCard = true;
        playerNumber = 1;
    }

    // Update is called once per frame
    void Update()
    {
    
    }
}

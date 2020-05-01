using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1Controller : MonoBehaviour
{
    public GameObject[] player1Spaces;
    public GameObject[] otherPlayersSpaces;
    public int spaceIndex;
    public bool canPlayCard;
    public int playerNumber;
    public bool isMyTurn;

    private GameObject[] GetBoardSpaces(string boardName)
    {
        GameObject[] boardSpaces = new GameObject[9];

        for(int i = 0; i < 9; i++)
        {
            boardSpaces[i] = GameObject.Find(boardName).GetComponent<Transform>().GetChild(i).gameObject;
        }
    
        return boardSpaces;
    }

    
    
    // Start is called before the first frame update
    void Start()
    {
        player1Spaces = GetBoardSpaces("BoardSpaces");
        otherPlayersSpaces = GetBoardSpaces("Other Players Board Spaces");
        spaceIndex = 0;
        canPlayCard = true;
        playerNumber = 1;
    }

    // Update is called once per frame
    void Update()
    {
    
    }
}

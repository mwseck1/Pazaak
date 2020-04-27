using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1Controller : MonoBehaviour
{
    public GameObject[] player1Spaces;
    public int spaceIndex;
    public bool canPlayCard;
    public int playerNumber;

    // Start is called before the first frame update
    void Start()
    {
        player1Spaces = GameObject.FindGameObjectsWithTag("Player1Space");
        spaceIndex = 0;
        canPlayCard = true;
        playerNumber = 1;
    }

    // Update is called once per frame
    void Update()
    {
    
    }
}

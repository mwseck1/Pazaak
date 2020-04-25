using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardSpace : MonoBehaviour
{
    int spaceScore;
    public bool hasCard;
   
    void OnTriggerEnter2D(Collider2D cardCollider)
    {
       if(cardCollider.gameObject.name != "GameBoard")
       {
            GameObject.Find("Player 1 Score").GetComponent<Player1ScoreBoard>().playerScore += 
                    cardCollider.gameObject.GetComponent<Card>().value;
            hasCard = true;
       }  
    }  

    // Start is called before the first frame update
    void Start()
    {
        spaceScore = 0;
        hasCard = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

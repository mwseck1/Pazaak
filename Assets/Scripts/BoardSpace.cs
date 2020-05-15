using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardSpace : MonoBehaviour
{
    public GameObject card;
   
    void OnTriggerEnter2D(Collider2D cardCollider)
    {
       if(cardCollider.gameObject.name != "GameBoard")
       {
            if(this.gameObject.tag == "Player1Space")
                GameObject.Find("Player 1 Score").GetComponent<Player1ScoreBoard>().playerScore += 
                        cardCollider.gameObject.GetComponent<Card>().value;
            else
                GameObject.Find("Player 2 Score").GetComponent<Player1ScoreBoard>().playerScore += 
                        cardCollider.gameObject.GetComponent<Card>().value;
            
            
            card = cardCollider.gameObject;   
       }  
    

    }  

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTurnButton : MonoBehaviour
{    
    P1Controller player1Controller;
    
    public void OnEndTurnButtonPress()
    {      
        CheckScore();
        GameObject.Find("MainDeck").GetComponent<MainDeck>().PlayNextCard(player1Controller.playerNumber);
    }
    
    void CheckScore()
    {
        if(GameObject.Find("Player 1 Score").GetComponent<Player1ScoreBoard>().playerScore > 20)
        {
            Debug.Log("Player 1 Loses");

            // reset the scene
        }
    }

    // Start is called before the first frame update
    void Start()
    {
       player1Controller = GameObject.Find("Player1").GetComponent<P1Controller>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

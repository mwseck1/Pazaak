using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainDeck : Deck
{
    GameObject nextSpace;
    GameObject[] player1Spaces;
    P1Controller player1Controller;
   // GameObject player2; 

    // Start is called before the first frame update
    void Start()
    {    
        for(int i = 1; i <= 10; i++)
        {
            card.GetComponent<Card>().value = i;
            if(i == 1)
            {
                cards.Add(Instantiate(card, new Vector3(0,0,0), Quaternion.identity) as GameObject);
                cards.Add(Instantiate(card, new Vector3(0,0,0), Quaternion.identity) as GameObject);
                cards.Add(Instantiate(card, new Vector3(0,0,0), Quaternion.identity) as GameObject);
                cards.Add(Instantiate(card, new Vector3(0,0,0), Quaternion.identity) as GameObject); 
            }
            else
            {
                cards.Add(Instantiate(card, new Vector3(0,0,0), Quaternion.identity) as GameObject);
                cards.Add(Instantiate(card, new Vector3(0,0,0), Quaternion.identity) as GameObject);
                cards.Add(Instantiate(card, new Vector3(0,0,0), Quaternion.identity) as GameObject);
                cards.Add(Instantiate(card, new Vector3(0,0,0), Quaternion.identity) as GameObject); 
            }
            
        }

       player1Controller = GameObject.Find("Player1").GetComponent<P1Controller>();
       
       PlayNextCard(2);
    }

    public void PlayNextCard(int playerNumber)
    {
        GameObject nextcard = cards[0];
        cards.RemoveAt(0);

        if(playerNumber == 1)
        {

        }
        else 
        {
            GameObject nextSpace = player1Controller.player1Spaces[player1Controller.spaceIndex];
            player1Controller.spaceIndex++;

            nextcard.GetComponent<Transform>().position = nextSpace.GetComponent<Transform>().position;
            nextcard.SetActive(true);
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon;
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;

public class MainDeck : Deck
{
    GameObject nextSpace;
    GameObject[] player1Spaces;
    P1Controller player1Controller;
   
    byte eventCode = 1;

    private void SendMove(int cardPlacementIndex , GameObject nextCard)
    { 
        RaiseEventOptions eventOptions = new RaiseEventOptions { Receivers = ReceiverGroup.Others };
        object[] moveInformation = new object[] { cardPlacementIndex, nextCard.GetComponent<Card>().value, "MainDeckCard" };
        SendOptions sendOptions = new SendOptions { Reliability = true };
        PhotonNetwork.RaiseEvent(eventCode, moveInformation ,eventOptions, sendOptions);
    }


    // Start is called before the first frame update
    void Start()
    {    
        for(int i = 1; i <= 10; i++)
        {
            card.GetComponent<Card>().value = i;
           
            cards.Add(Instantiate(card, new Vector3(0,0,0), Quaternion.identity) as GameObject);
            cards.Add(Instantiate(card, new Vector3(0,0,0), Quaternion.identity) as GameObject);
            cards.Add(Instantiate(card, new Vector3(0,0,0), Quaternion.identity) as GameObject);
            cards.Add(Instantiate(card, new Vector3(0,0,0), Quaternion.identity) as GameObject);  
        }

       player1Controller = GameObject.Find("Player1").GetComponent<P1Controller>();
    }

    public void PlayNextCard()
    {
        GameObject nextCard = cards[0];
        cards.RemoveAt(0);

        GameObject nextSpace = player1Controller.player1Spaces[player1Controller.spaceIndex];
    
        nextCard.GetComponent<Transform>().position = nextSpace.GetComponent<Transform>().position;
        nextCard.SetActive(true);

        SendMove(player1Controller.spaceIndex, nextCard);
    
        player1Controller.spaceIndex++;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

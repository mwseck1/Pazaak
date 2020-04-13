using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTurnButton : MonoBehaviour
{
    GameObject[] player1Spaces;
    GameObject nextSpace;
    List<GameObject> mainDeckCards;
    int spaceIndex;
    

    public void OnEndTurnButtonPress()
    {
        GameObject nextcard = mainDeckCards[0];
        mainDeckCards.RemoveAt(0);

        GameObject nextSpace = player1Spaces[spaceIndex];
        spaceIndex++;

        nextcard.GetComponent<Transform>().position = nextSpace.GetComponent<Transform>().position;
        nextcard.SetActive(true);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        player1Spaces = GameObject.FindGameObjectsWithTag("Player1Space");
        mainDeckCards = GameObject.Find("MainDeck").GetComponent<MainDeck>().cards;
        spaceIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

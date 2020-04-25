using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideDeck : Deck
{
    int min;
    int max;
    List<GameObject> playableCards = new List<GameObject>();
    GameObject[] playerHandSpaces;

    // Start is called before the first frame update
    void Start()
    {
        min = 0; 
        max = 9;

        playerHandSpaces = GameObject.FindGameObjectsWithTag("Player1HS");

        for(int i = 1; i <= 5; i++)
        {
            card.GetComponent<Card>().value = i;
            cards.Add(Instantiate(card, new Vector3(0,0,0), Quaternion.identity) as GameObject);
            cards.Add(Instantiate(card, new Vector3(0,0,0), Quaternion.identity) as GameObject);
        }

        System.Random random = new System.Random();

        for(int i = 0; i < 4; i++)
        {
            int index = random.Next(min, max);
            playableCards.Add(cards[index]);
            cards.RemoveAt(index);
            max --;
        }

        for(int i = 0; i < 4; i++)
        {
            playableCards[i].GetComponent<Transform>().position = playerHandSpaces[i].GetComponent<Transform>().position;
            playableCards[i].SetActive(true);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

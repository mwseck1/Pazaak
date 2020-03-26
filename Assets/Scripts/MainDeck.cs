using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainDeck : Deck
{
    // Start is called before the first frame update
    void Start()
    {    
        for(int i = 1; i <= 10; i++)
        {
            card.GetComponent<Card>().value = i;
            if(i == 1)
            {
                card.SetActive(true);
                Vector3 firstPosition = GameObject.Find("Space").GetComponent<Transform>().position;

                cards.Add(Instantiate(card, firstPosition, Quaternion.identity) as GameObject);
                
                card.SetActive(false);
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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

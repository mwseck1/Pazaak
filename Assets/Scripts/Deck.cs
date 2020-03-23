using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    public GameObject card;
    public List<GameObject> cards = new List<GameObject>(); 

    // Start is called before the first frame update
    void Start()
    {
       for(int i = 0; i < 2; i++)
       {
           card.GetComponent<Card>().value = i;
           cards.Add(Instantiate(card, new Vector3(0,0,0), Quaternion.identity) as GameObject); 
       }
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

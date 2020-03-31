using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardSpace : MonoBehaviour
{
    int spaceScore;
    bool hasCard;
   
    void OnTriggerEnter2D(Collider2D cardCollider)
    {
       spaceScore = cardCollider.gameObject.GetComponent<Card>().value;
       hasCard = true;
    }  

    // Start is called before the first frame update
    void Start()
    {
        spaceScore = 0;
        hasCard = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

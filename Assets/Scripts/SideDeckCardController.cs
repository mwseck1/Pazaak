﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideDeckCardController : MonoBehaviour
{
    private Vector3 originalPosition;
    private RaycastHit dropRay;
    private P1Controller player1Controller;
   
    void OnMouseDrag()
    {
       if(player1Controller.canPlayCard)
       {
           GetComponent<BoxCollider2D>().enabled = false;
            Vector3 mousePosition = Input.mousePosition;    
        
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition); 
            mousePosition.z = 1;
        
            GetComponent<Transform>().position = mousePosition;
       }   
    }
    
    void OnMouseUp()
    {
        GetComponent<BoxCollider2D>().enabled = true;
       
        Physics.Raycast(transform.position, new Vector3(0,0, -1), out dropRay);

        if(dropRay.collider != null)
        {
            transform.position = player1Controller.player1Spaces[player1Controller.spaceIndex].GetComponent<Transform>().position;
            player1Controller.spaceIndex ++;
            player1Controller.canPlayCard = false;
        }
        else
        {
            GetComponent<Transform>().position = originalPosition;
        }
       
    }

    // Start is called before the first frame update
    void Start()
    {
        originalPosition = GetComponent<Transform>().position;
        player1Controller = GameObject.Find("Player1").GetComponent<P1Controller>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

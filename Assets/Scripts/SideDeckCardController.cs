using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideDeckCardController : Card
{
    private Vector3 originalPosition;
    RaycastHit dropRay;
   
    void OnMouseDrag()
    {
        GetComponent<BoxCollider2D>().enabled = false;
        Vector3 mousePosition = Input.mousePosition;    
        
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition); 
        mousePosition.z = 1;
        
        GetComponent<Transform>().position = mousePosition;
    }
    
    void OnMouseUp()
    {
        GetComponent<BoxCollider2D>().enabled = true;
       
        Physics.Raycast(transform.position, new Vector3(0,0, -1), out dropRay);

        if(dropRay.collider != null)
        {
            Debug.Log(dropRay.collider.name);
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
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}

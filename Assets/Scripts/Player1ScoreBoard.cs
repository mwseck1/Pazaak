using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player1ScoreBoard : MonoBehaviour
{
    public int playerScore;
    public string playerName;

    // Start is called before the first frame update
    void Start()
    {
        playerScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Text>().text = playerName + " Score: " + playerScore;
    }
}

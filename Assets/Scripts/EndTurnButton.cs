using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;

public class EndTurnButton : MonoBehaviourPun
{    
    P1Controller player1Controller;
    Player1ScoreBoard myScoreBoard;
    Player1ScoreBoard theirScoreBoard;
    byte eventCode = 2;

    public void SendEndTurn(bool hasLost)
    {
        RaiseEventOptions eventOptions = new RaiseEventOptions { Receivers = ReceiverGroup.Others };
        SendOptions sendOptions = new SendOptions { Reliability = true };
        PhotonNetwork.RaiseEvent(eventCode, hasLost ,eventOptions, sendOptions);

        if(hasLost)
        {
           player1Controller.spaceIndex = 0;
           player1Controller.ResetGameBoards();

           myScoreBoard.playerScore = 0;
           theirScoreBoard.playerScore = 0;
        }
    }

    public void OnEndTurnButtonPress()
    {    
       if(player1Controller.isMyTurn)
       {
           player1Controller.isMyTurn = false;
           player1Controller.canPlayCard = false;  
           bool hasLost = CheckScore();
           SendEndTurn(true);
       }
        
    }
    
    bool CheckScore()
    {
        if(myScoreBoard.playerScore > 20)
            return true;
        else
            return false;
    }

    // Start is called before the first frame update
    void Start()
    {
       player1Controller = GameObject.Find("Player1").GetComponent<P1Controller>();
       myScoreBoard = GameObject.Find("Player 1 Score").GetComponent<Player1ScoreBoard>();
       theirScoreBoard = GameObject.Find("Player 2 Score").GetComponent<Player1ScoreBoard>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

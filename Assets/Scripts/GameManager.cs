using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;

public class GameManager : MonoBehaviourPunCallbacks, IOnEventCallback
{
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject myScoreBoard;
    [SerializeField]
    private GameObject theirScoreBoard;
    private GameObject CardPrefab;

    public void OnEvent(EventData otherPlayersMove)
    {
        if(otherPlayersMove.Code == 1)
        {
            GameObject[] otherBoardSpaces = player.GetComponent<P1Controller>().otherPlayersSpaces;

            object[] recievedData = (object[]) otherPlayersMove.CustomData;
            int cardPlacementBoardIndex = (int)recievedData[0];
            int movedCardValue = (int)recievedData[1];
            string prefabName = (string)recievedData[2];

            CardPrefab = (GameObject)Resources.Load(prefabName);

            Vector3 cardPlacementPosition = otherBoardSpaces[cardPlacementBoardIndex].GetComponent<Transform>().position;
            CardPrefab.GetComponent<Card>().value = movedCardValue;

            GameObject newCard = Instantiate(CardPrefab, cardPlacementPosition, Quaternion.identity);   

            newCard.SetActive(true);
        }
        else if(otherPlayersMove.Code == 2)
        {
             bool hasOtherPlayerLost = (bool) otherPlayersMove.CustomData;
             P1Controller playerController = player.GetComponent<P1Controller>();

             if(hasOtherPlayerLost)
             {
                playerController.spaceIndex = 0;
                playerController.ResetGameBoards();

                myScoreBoard.GetComponent<Player1ScoreBoard>().playerScore = 0;
                theirScoreBoard.GetComponent<Player1ScoreBoard>().playerScore = 0;
             }
             else
             {
                GameObject.Find("MainDeck").GetComponent<MainDeck>().PlayNextCard();
                
                playerController.canPlayCard = true;
                playerController.isMyTurn = true;
             }
        }
    }

    public void OnEnable()
    {
        PhotonNetwork.AddCallbackTarget(this);
    }

    public void OnDisable()
    {
        PhotonNetwork.RemoveCallbackTarget(this);
    }

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
    }

    public override void OnLeftRoom()
    {
        SceneManager.LoadScene(0);
    }

    public override void OnPlayerEnteredRoom(Player player)
    {
        Debug.Log("Player " + player.NickName + " connected.");

        if(PhotonNetwork.IsMasterClient && PhotonNetwork.CurrentRoom.PlayerCount == 2)
            GameObject.Find("MainDeck").GetComponent<MainDeck>().PlayNextCard();
            
    }

    public override void OnPlayerLeftRoom(Player player)
    {
        Debug.Log("Player " + player.NickName + " disconnected.");
 
        PhotonNetwork.LoadLevel(0);
    }

}

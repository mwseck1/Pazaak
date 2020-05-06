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
    }

    public override void OnPlayerLeftRoom(Player player)
    {
        Debug.Log("Player " + player.NickName + " disconnected.");

         
        PhotonNetwork.LoadLevel(0);
        
    }


}

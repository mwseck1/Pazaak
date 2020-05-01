using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;

public class GameManager : MonoBehaviourPunCallbacks, IOnEventCallback
{
    public void OnEvent(EventData otherPlayersMove)
    {
        if(otherPlayersMove.Code == 1)
        {
            int cardPlacementBoardIndex = (int)otherPlayersMove.CustomData;

            
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Launcher : MonoBehaviourPunCallbacks
{
    string gameVersion = "1";
    
    //serialize field allows us to expose private variables in the inspector
    [SerializeField]
    private byte maxPlayersPerRoom = 2;
    [SerializeField]
    private GameObject controlPanel;
    [SerializeField]
    private GameObject connectionText;
    private bool isConnecting;

    public override void OnConnectedToMaster()
    {
        Debug.Log("OnConnectedToMaster() called");
        
        if(isConnecting)
        {    
            PhotonNetwork.JoinRandomRoom();    
        }
    }   

    public override void OnDisconnected(DisconnectCause cause)
    {
        controlPanel.SetActive(true);
        connectionText.SetActive(false);

        Debug.LogWarningFormat("PUN Basics Tutorial/Launcher: OnDisconnected() was called by PUN with reason {0}", cause);
    }
    
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("No room available");
    
        PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = maxPlayersPerRoom });
    }

    public override void OnJoinedRoom()
    {
        if(PhotonNetwork.IsMasterClient)
        {
            Debug.Log("Room 1 successfully joined.");
            PhotonNetwork.LoadLevel(1);
        }
        else
        {
            PhotonNetwork.LoadLevel(2);
        }
    }

    void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        controlPanel.SetActive(true);
        connectionText.SetActive(false);
    }

    public void Connect()
    {
        connectionText.SetActive(true);
        controlPanel.SetActive(false);

        if(PhotonNetwork.IsConnected)
        {
            PhotonNetwork.JoinRandomRoom();
        }  
        else
        {
            //connects client to server
            isConnecting = PhotonNetwork.ConnectUsingSettings();
            
            //sets version for client
            PhotonNetwork.GameVersion = gameVersion;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

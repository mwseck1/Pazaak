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
            isConnecting = false;
        }
    }   

    public override void OnDisconnected(DisconnectCause cause)
    {
        controlPanel.SetActive(true);
        connectionText.SetActive(false);

        isConnecting = false;
        
        Debug.LogWarningFormat("PUN Basics Tutorial/Launcher: OnDisconnected() was called by PUN with reason {0}", cause);
    }
    
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("No room available");
    
        PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = maxPlayersPerRoom });
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Room successfully joined.");

        PhotonNetwork.LoadLevel(1);
    }

    void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
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

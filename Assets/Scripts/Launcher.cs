using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Launcher : MonoBehaviour
{
    string gameVersion = "1";

    void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        Connect();
    }

    public void Connect()
    {
        if(PhotonNetwork.IsConnected)
        {
            PhotonNetwork.JoinRandomRoom();
        }
        else
        {
            //connects client to server
            PhotonNetwork.ConnectUsingSettings();
            
            //sets version for client
            PhotonNetwork.GameVersion = gameVersion;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

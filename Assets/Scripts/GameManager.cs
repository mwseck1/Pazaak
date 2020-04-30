using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class GameManager : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void OnPlayerEnteredRoom(Player player)
    {
        Debug.Log("Player " + player.NickName + " connected.");
        
        if(PhotonNetwork.IsMasterClient)
        {
            LoadGameScene(1);
        }
    }

    public override void OnPlayerLeftRoom(Player player)
    {
        Debug.Log("Player " + player.NickName + " disconnected.");

        if(PhotonNetwork.IsMasterClient)
        {
            LoadGameScene(0);
        }
    }


    private void LoadGameScene(int levelNumber)
    {
        if(PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.LoadLevel(levelNumber);
        }
    }

}

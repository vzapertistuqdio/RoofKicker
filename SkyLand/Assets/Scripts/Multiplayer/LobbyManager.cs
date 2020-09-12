using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    [SerializeField] Text logText;
   private void Start()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.NickName = "Player" + Random.Range(0, 1000).ToString();
        Log("Players name set to:"+PhotonNetwork.NickName);
        PhotonNetwork.GameVersion = "1";
        PhotonNetwork.ConnectUsingSettings();
    }

    
    private void Update()
    {
        
    }
    public override void OnConnectedToMaster()
    {
        Log("Connected to Master-server");
    }
    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom(null,new Photon.Realtime.RoomOptions {MaxPlayers=2 });
    }
    public void JoinRoom()
    {
        PhotonNetwork.JoinRandomRoom();
    }
    public override void OnJoinedRoom()
    {
        Log("Joined to room");
        PhotonNetwork.LoadLevel("MultiplayerScene1");
    }

    private void Log(string text)
    {
        logText.text += "\n";
        logText.text += text;
    }
}

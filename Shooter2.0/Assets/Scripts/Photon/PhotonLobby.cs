using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotonLobby : MonoBehaviourPunCallbacks
{

    public static PhotonLobby lobby;
    public GameObject battleButton;
    public GameObject cancelButton;

    // Start is called before the first frame update
    void Awake()
    {
        lobby = this; //creates singleton
    }

    private void Start()
    {
        PhotonNetwork.ConnectUsingSettings(); //connects to photon server
    }


    public void OnCancelButtonClicked()
    {
        battleButton.SetActive(true);
        cancelButton.SetActive(false);
        PhotonNetwork.LeaveRoom();
    }


    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        Debug.Log("Connected");
        PhotonNetwork.AutomaticallySyncScene = true;
        battleButton.SetActive(true);
    }

    public void OnBattleClicked()
    {
        battleButton.SetActive(false);
        cancelButton.SetActive(true);
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        base.OnJoinRandomFailed(returnCode, message);
        Debug.Log("Failed to join random room. No rooms available. Creating Room.");
        CreateRoom();
       
    }

    void CreateRoom()
    {
        
        int randRoom = Random.Range(0, 10000);
        RoomOptions roomops = new RoomOptions() { IsVisible = true, IsOpen = true, MaxPlayers = 10 };
        PhotonNetwork.CreateRoom("Room", roomops);
        Debug.Log("Room " + randRoom + " successfully created");
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("Room Create Failed. Trying again.");
        CreateRoom();
        base.OnCreateRoomFailed(returnCode, message);
    }
}

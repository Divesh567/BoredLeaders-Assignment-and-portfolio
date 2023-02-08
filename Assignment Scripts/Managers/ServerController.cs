using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;
using TMPro;

public class ServerController : MonoBehaviourPunCallbacks
{
    private static ServerController _instance;
    public static ServerController Instance { get { return _instance; } }
    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    private void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();
        MainMenu.Instance.UpdateConnectionStatus(true);
    }

    public void CreateRoom()
    {
        if (PhotonNetwork.CountOfRooms == 0)
        {
            PhotonNetwork.CreateRoom("Room1");

        }
        else
        {
            Debug.Log("RoomExists");
        }
    }

    public override void OnCreatedRoom()
    {
        base.OnCreatedRoom();
        
    }

    public void JoinRoom()
    {
        if (PhotonNetwork.CountOfRooms > 0)
        {
            PhotonNetwork.JoinRoom("Room1");
        }
        else
        {
            Debug.Log("No Room Exist Please Host");
        }
    }
    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel(1);
        MenuManager.Instance.CloseMenu(MainMenu.Instance);
    }
}

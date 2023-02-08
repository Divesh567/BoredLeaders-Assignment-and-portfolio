using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class myGameManager : MonoBehaviourPunCallbacks
{
    private static myGameManager _instance;

    public static myGameManager Instance { get { return _instance; } }


    public static bool StartGame;

    private PhotonView _pHView;
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

    private void Update()
    {
        if (!StartGame && PhotonNetwork.CurrentRoom != null)
        {
            GameMenu.Instance.ShowWaitingForPlayers(true);
            if(PhotonNetwork.CurrentRoom.PlayerCount > 1)
            {
                StartGame = true;
                GameMenu.Instance.ShowWaitingForPlayers(false);
                GameMenu.Instance.EnablePlayerTurnText();
            }
            
        }
    }
}

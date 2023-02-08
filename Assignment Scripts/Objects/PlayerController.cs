using System.Collections;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class PlayerController : MonoBehaviourPunCallbacks,IPunObservable
{
    private PhotonView _photonView;

    [SerializeField]
    private Vector3 _player1Pos;
    [SerializeField]
    private Vector3 _player2Pos;
    [SerializeField]
    private Vector3 _player3Pos;
    [SerializeField]
    private Vector3 _player4Pos;

    
    private void Start()
    {
        _photonView = GetComponent<PhotonView>();
        RepositionPlayer();
       
    }

    private void RepositionPlayer()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            if (_photonView.IsMine)
            {
                transform.position = _player1Pos;
            }
        }
        else
        {
            if (PhotonNetwork.CurrentRoom.PlayerCount == 2)
            {
                if (_photonView.IsMine)
                {
                    transform.position = _player2Pos;
                }
            }
            else if (PhotonNetwork.CurrentRoom.PlayerCount == 3)
            {
                if (_photonView.IsMine)
                {
                    transform.position = _player3Pos;
                }
                
            }
            else if (PhotonNetwork.CurrentRoom.PlayerCount == 4)
            {
                if (_photonView.IsMine)
                {
                    transform.position = _player4Pos;
                }


            }
        }
    }
    
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
    }
}

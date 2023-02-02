using System.Collections;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class PlayerController : MonoBehaviourPunCallbacks,IPunObservable
{
    public ExitGames.Client.Photon.Hashtable playerProperties = new ExitGames.Client.Photon.Hashtable();
    private PhotonView _photonView;

    [SerializeField]
    private Vector3 _player1Pos;
    [SerializeField]
    private Vector3 _player2Pos;
    [SerializeField]
    private Vector3 _player3Pos;
    [SerializeField]
    private Vector3 _player4Pos;

    private Vector3 _startpos;
    private Vector3 _currentPos;
    private Vector3 _targetPos;
    [SerializeField]
    private float _moveSpeed = 0.05f;
    private bool _isMoving;
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
                _startpos = _player1Pos;
            }
        }
        else
        {
            if (PhotonNetwork.CurrentRoom.PlayerCount == 2)
            {
                if (_photonView.IsMine)
                {

                    transform.position = _player2Pos;
                    _startpos = _player2Pos;
                }
            }
            else if (PhotonNetwork.CurrentRoom.PlayerCount == 3)
            {
                if (_photonView.IsMine)
                {

                    transform.position = _player3Pos;
                    _startpos = _player3Pos;
                }
                
            }
            else if (PhotonNetwork.CurrentRoom.PlayerCount == 4)
            {
                if (_photonView.IsMine)
                {
                    transform.position = _player4Pos;
                    _startpos = _player4Pos;
                }


            }
        }
    }

    private void Update()
    {
        if (myGameManager.StartGame)
        {
            if (PhotonNetwork.IsMasterClient && _photonView.IsMine)
            {
                if (Input.GetKeyDown(KeyCode.W) && !_isMoving)
                {
                    StartCoroutine(MovePlayer(Vector3.forward));
                }
                else if (Input.GetKeyDown(KeyCode.S) && !_isMoving)
                {
                    StartCoroutine(MovePlayer(Vector3.back));
                }
                else if (Input.GetKeyDown(KeyCode.A) && !_isMoving)
                {
                    StartCoroutine(MovePlayer(Vector3.left));
                }

                else if (Input.GetKeyDown(KeyCode.D) && !_isMoving)
                {
                    StartCoroutine(MovePlayer(Vector3.right));
                }
            }
        }
    }


    /*private void UpdateTurnValue()
    {
        turn = turn++;
        playerProperties.Add("Turn", turn);
        PhotonNetwork.LocalPlayer.SetCustomProperties(playerProperties);
    }
    public override void OnPlayerPropertiesUpdate(Player targetPlayer, ExitGames.Client.Photon.Hashtable changedProps)
    {
        if ((int)targetPlayer.CustomProperties["Turn"] == turn)
        {

        }
    }*/



    IEnumerator MovePlayer(Vector3 _movePos)
    {
        _isMoving = true;
        float elaspedTime = 0f;
        _currentPos = transform.position;
        _targetPos = _currentPos + _movePos;
        while (elaspedTime < _moveSpeed)
        {
            transform.position = Vector3.Lerp(_currentPos, _targetPos, elaspedTime / _moveSpeed);
            elaspedTime += Time.deltaTime;
        }
        transform.position = _targetPos;
        _isMoving = false;
        yield return null;
        SwitchMasterClient();
    }

    public void SwitchMasterClient()
    {
        PhotonNetwork.SetMasterClient(PhotonNetwork.MasterClient.GetNext());
    }
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Respawn"))
        {
            transform.position = _startpos;
        }
        else if (other.CompareTag("Finish"))
        {
            Debug.Log("You win");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayersManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _playerPrefab;
    void Start()
    {
        PhotonNetwork.Instantiate(_playerPrefab.name, transform.position, Quaternion.identity);
    }

}

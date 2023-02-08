using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;
using UnityEngine.UI;

public class GameMenu : Menu<GameMenu>
{
    private GameObject _waitingForPlayers;
    private GameObject _playerTurn;
    private void Start()
    {
        _waitingForPlayers = transform.GetChild(0).gameObject;
        _playerTurn = transform.GetChild(1).gameObject;
    }

    public override void MenuOpen()
    {
        base.MenuOpen();
    }
    public override void MenuClose()
    {
        base.MenuClose();
    }

    public void ShowWaitingForPlayers(bool _show)
    {
        _waitingForPlayers.SetActive(_show);
    }

    public void EnablePlayerTurnText()
    {
        _playerTurn.SetActive(true);
    }
    public void ShowPlayerTurn(string turnText)
    {
        
        _playerTurn.GetComponent<TextMeshProUGUI>().text = turnText;   
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;
using UnityEngine.UI;

public class GameMenu : Menu<GameMenu>
{
    private GameObject _waitingForPlayers;
    private void Start()
    {
        _waitingForPlayers = transform.GetChild(0).gameObject;
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
}

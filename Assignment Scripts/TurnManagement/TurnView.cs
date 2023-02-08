using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnView : MonoBehaviour
{
    private TurnPresenter _presenter;

    private void Start()
    {
        _presenter = new TurnPresenter();
        _presenter.Init(this);
    }

    public void ShowPlayerTurn(string _turn)
    {
        GameMenu.Instance.ShowPlayerTurn(_turn);
    }
}

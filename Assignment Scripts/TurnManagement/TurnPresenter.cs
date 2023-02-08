using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnPresenter 
{
    private TurnView _view;
    private TurnData _data;

    public void Init(TurnView view)
    { 
        _view = view;
        _data = new TurnData();
    }
}

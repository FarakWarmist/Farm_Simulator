using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitCommand : ICommand
{
    private GameShop _gameShop;

    public ExitCommand(GameShop gameShop)
    {
        _gameShop = gameShop;
    }

    public void Execute()
    {
        _gameShop.CloseShop();
    }
}

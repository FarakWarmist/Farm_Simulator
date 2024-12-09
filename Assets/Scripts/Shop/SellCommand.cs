using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellCommand : ICommand
{
    private ISell _sell;

    public SellCommand(ISell sell)
    {
        _sell = sell;
    }

    public void Execute()
    {
        _sell.Sell();
    }
}

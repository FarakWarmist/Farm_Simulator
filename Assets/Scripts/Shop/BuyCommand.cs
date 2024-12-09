using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyCommand : ICommand
{
    private ProductType _productType;
    private IBuy _buyHandler;

    public BuyCommand(ProductType productType, IBuy buy)
    {
        _productType = productType;
        _buyHandler = buy;
    }

    public void Execute()
    {
        _buyHandler.Buy(_productType);
    }
}

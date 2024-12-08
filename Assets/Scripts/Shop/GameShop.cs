using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class GameShop : MonoBehaviour
{
    [SerializeField] private Transform _parentTransform;
    [SerializeField] private Button _buttonPrefab;
    [SerializeField] protected SubTitle _subTitle;
    [SerializeField] private Image _goldPlayerImage;

    protected ShopUIManager _shopUIManager;
    protected ButtonFactory _buttonFactory;
    protected PlayerData _playerData;
    protected ProduitManager _produitManager;

    private IBuy _buyHandler;
    private ISell _sellHandler;

    private void Start()
    {
        _shopUIManager = new ShopUIManager(_parentTransform);
        _buttonFactory = new ButtonFactory(_parentTransform, _buttonPrefab, _shopUIManager);

        _buyHandler = GetComponent<IBuy>();
        _sellHandler = GetComponent<ISell>();

        _produitManager = new ProduitManager();
        _playerData = GameManagerPlayerData.Instance.PlayerData;

        _goldPlayerImage.gameObject.SetActive(false);
    }

    public void Shop(ProduitType produitType)
    {
        _subTitle.SetSubtitle("Bonjour, comment je peux vous aider ajourd'hui");

        //Sauvegarder la position original
        _shopUIManager.ClearUI();
        _shopUIManager.ResetPosition();
        Time.timeScale = 0;

        //Cree le button Acheter
        _buttonFactory.CreateButton("Acheter", () => _buyHandler.Buy(produitType));
        _shopUIManager.DecreaseYPosition();

        //Cree le Button Vendre
        _buttonFactory.CreateButton("Vendre", () => _sellHandler.Sell());
        _shopUIManager.DecreaseYPosition();

        //Cree le button Exit
       ExitButton();
    }

    protected void CloseShop()
    {
        Time.timeScale = 1f;
        _shopUIManager.ClearUI();
        _subTitle.SetSubtitle("Bonne journee !!", 3);
        _goldPlayerImage.gameObject.SetActive(false);
    }

    protected void ExitButton()
    {
        _buttonFactory.CreateButton("Exit", () => CloseShop());
    }

    protected void ShowGold()
    {
        _goldPlayerImage.gameObject.SetActive(true);
        _goldPlayerImage.GetComponentInChildren<TMP_Text>().text = $"Gold: {_playerData.Gold}";
    }
}

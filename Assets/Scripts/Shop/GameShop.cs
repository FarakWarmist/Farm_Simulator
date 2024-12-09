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
    [SerializeField] private Image _goldPlayerImage;
    [SerializeField] protected Subtitles _subTitle;

    protected ShopUIManager _shopUIManager;
    protected ButtonFactory _buttonFactory;
    protected PlayerData _playerData;
    protected ProductManager _produitManager;

    private void Start()
    {
        _shopUIManager = new ShopUIManager(_parentTransform);
        _buttonFactory = new ButtonFactory(_parentTransform, _buttonPrefab, _shopUIManager);

        _produitManager = new ProductManager();
        _playerData = GameManagerPlayerData.Instance.PlayerData;

        _goldPlayerImage.gameObject.SetActive(false);
    }

    public void Shop(ProductType productType, IBuy buyHandler, ISell sellHandler)
    {
        _subTitle.SetSubtitle("Bonjour, comment je peux vous aider ajourd'hui");

        //Sauvegarder la position original
        _shopUIManager.ClearUI();
        _shopUIManager.ResetPosition();
        Time.timeScale = 0;

        //Cree le button Acheter
        AddCommandButton(new BuyCommand(productType, buyHandler),"Acheter");

        //Cree le Button Vendre
        AddCommandButton(new SellCommand(sellHandler),"Vendre");

        //Cree le button Exit
        AddCommandButton(new ExitCommand(this), "Quitter");
    }

    //Patron de Commande
    private void AddCommandButton(ICommand command, string text)
    {
        _buttonFactory.CreateButton(text, () => command.Execute());
        _shopUIManager.DecreaseYPosition();
    }

    //Pour Fermer le Shop
    public void CloseShop()
    {
        Time.timeScale = 1f;
        _shopUIManager.ClearUI();
        _subTitle.SetSubtitle("Bonne journee !!", 3);
        _goldPlayerImage.gameObject.SetActive(false);
    }

    //cree lle button exit
    protected void ExitButton()
    {
        _buttonFactory.CreateButton("Exit", () => CloseShop());
    }

    //Montrer combien de Gold a le Player
    protected void ShowGold()
    {
        _goldPlayerImage.gameObject.SetActive(true);
        _goldPlayerImage.GetComponentInChildren<TMP_Text>().text = $"Gold: {_playerData.Gold}";
    }
}

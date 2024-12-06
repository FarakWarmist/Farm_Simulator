using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class GameShop : MonoBehaviour
{
    [SerializeField] protected Transform _parentTransform;
    [SerializeField] protected Button _buttonPrefab;
    protected Vector3 _originalButtonPossition;
    protected float yPosition;

    private IBuy _buyHandler;
    private ISell _sellHandler;

    private void Awake()
    {
        _buyHandler = GetComponent<IBuy>();
        _sellHandler = GetComponent<ISell>();
    }

    public void Shop(ProduitType produitType)
    {
        //Sauvegarder la position original
        _originalButtonPossition = _parentTransform.transform.localPosition;
        float xPosition = _originalButtonPossition.x;
        float yPosition = 500f;

        Time.timeScale = 0;

        //Cree le button Acheter
        CreateButton(new Vector3(xPosition, yPosition, 0), "Acheter", () =>
        {

            if (_buyHandler != null)
            {
                _buyHandler.Buy(produitType);
            }
            else
            {
                Debug.Log("IAcheter = null");
            }
        });

        yPosition -= 100f;

        //Cree le button Vendre
        CreateButton(new Vector3(xPosition, yPosition, 0), "Vendre", () =>
        {

            if (_sellHandler != null)
            {
                _sellHandler.Vendre();
            }
        });

        yPosition -= 100f;

        ExitShop();
    }
    
    //Pour cree des Buttons 
    protected Button CreateButton(Vector3 position, string text, UnityAction action)
    {
        //Cree un button 
        Button button = Instantiate(_buttonPrefab, _parentTransform.transform);
        button.transform.localPosition = position;
        button.GetComponentInChildren<TMP_Text>().text = text;
        button.onClick.AddListener(action);
        return button;
    }

    //Pour supprimer ce qu'il ya dans le parent (les Buttons)
    protected void ClearUI()
    {
        if (_parentTransform.transform.childCount > 0)
        {
            foreach (Transform child in _parentTransform.transform)
            {
                Destroy(child.gameObject);
            }
        }
    }

    //Pour quitter la boutique
    protected void ExitShop()
    {
        //Sauvegarder la position original
        _originalButtonPossition = _parentTransform.transform.localPosition;
        float xPosition = _originalButtonPossition.x;

        //Exit Button
        CreateButton(new Vector3(xPosition, yPosition, 0), "Exit", ClickExitBoutique); 
    }

    //Pour Updater l'affichage des produits 
    protected void UpdateTextButton(Produit item, Button button)
    {
        TMP_Text buttonText = button.GetComponentInChildren<TMP_Text>();

        button.GetComponentInChildren<TMP_Text>().text = item.ToString();
    }

    protected void QuitShopState(string text)
    {
        SubTitle.Instance.SetSubtitle(text, 3);
        Time.timeScale = 1f;
        ClearUI();
        return;
    }


    private void ClickExitBoutique()
    {
        ClearUI();
        Time.timeScale = 1f;
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [SerializeField] protected SubTitle _subTitle;
    [SerializeField] protected Transform _parentTransform;
    [SerializeField] protected Button _buttonPrefab;
    protected Vector3 _originalButtonPossition;
    protected float y;

    public void ShowOption(ProduitType produitType)
    {
        //Sauvegarder la position original
        _originalButtonPossition = _parentTransform.transform.localPosition;
        float x = _originalButtonPossition.x;
        y = 500;

        Time.timeScale = 0f;

        //Cree le button Acheter
        Vector3 acheterPosition = new Vector3(x, y, 0);
        Button acheter = Instantiate(_buttonPrefab, _parentTransform.transform);
        acheter.transform.localPosition = acheterPosition;
        acheter.GetComponentInChildren<TMP_Text>().text = "Acheter";
        acheter.onClick.AddListener(() =>
        {
            IAcheter acheterProduit = GetComponent<IAcheter>();

            if (acheterProduit == null)
            {
                Debug.LogError("Aucun composant IAcheter trouvé sur cet objet !");
                return;
            }
            acheterProduit.Acheter(produitType);
        });


        y -= 100; //Deplacer le prochain button plus bas


        //Cree le button Vendre
        Vector3 vendrePosition = new Vector3(x, y, 0);
        Button vendre = Instantiate(_buttonPrefab, _parentTransform.transform);
        vendre.transform.localPosition = vendrePosition;
        vendre.GetComponentInChildren<TMP_Text>().text = "Vendre";
        vendre.onClick.AddListener(() =>
        {
            IVendre vendreProduit = GetComponent<IVendre>();
            vendreProduit.Vendre();
        });
        y -= 100; //Deplacer le prochain button plus bas

        Exit();
    }

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

    public void Exit()
    {
        //Savegarder la possition du button 
        _originalButtonPossition = _parentTransform.transform.localPosition;
        float x = _originalButtonPossition.x;
        Vector3 ExitPosition = new Vector3(x, y, 0);

        //Cree le button Sortir
        Button exit = Instantiate(_buttonPrefab, _parentTransform.transform);
        exit.transform.localPosition = ExitPosition;
        exit.GetComponentInChildren<TMP_Text>().text = "Exit";
        exit.onClick.AddListener(() => ClickExitBoutique());
    }

    public void ClickExitBoutique()
    {
        ClearUI();
        Time.timeScale = 1f;
    }

    public void UpdateTextButton(Produit item, Button button)
    {
        TMP_Text buttonText = button.GetComponentInChildren<TMP_Text>();

        button.GetComponentInChildren<TMP_Text>().text = item.ToString();
    }
}

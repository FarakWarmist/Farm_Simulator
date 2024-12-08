using System.Collections.Generic;
using System.Linq;

public class ProduitManager
{
    private static List<Produit> _produitNPC = new List<Produit>();
    private static List<Produit> _produitPlayer = new List<Produit>();

    public static List<Produit> ProduitsNPC => _produitNPC;
    public static List<Produit> ProduitsPlayer => _produitPlayer;

    public void AddProduit(Produit item)
    {
        if (CheckProductExist(item, item.ProduitVendeur))
        {
            var findItem = item.ProduitVendeur == ProduitType.Player ? ProduitsPlayer : ProduitsNPC;
            var exitingProduct = findItem.First(p => p.ProduitName == item.ProduitName);
            exitingProduct.Quantiter++;
        }
        else
        {
            if (item.ProduitVendeur == ProduitType.Player)
            {
                ProduitsPlayer.Add(item);
            }
            else
            {
                ProduitsNPC.Add(item);
            }
        }
    }

    public void RemoveItem(Produit item)
    {
        if (item.ProduitVendeur == ProduitType.Player)
        {
            ProduitsPlayer.Remove(item);
        }
        else
        {
            ProduitsNPC.Remove(item);
        }
    }

    private bool CheckProductExist(Produit produit, ProduitType produitType)
    {
        var check = produitType == ProduitType.Player ? _produitPlayer : _produitNPC;
        return check.Any(p => p.ProduitName == produit.ProduitName);
    }
}

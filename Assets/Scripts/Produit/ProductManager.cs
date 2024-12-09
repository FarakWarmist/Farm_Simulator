using System.Collections.Generic;
using System.Linq;

public class ProductManager
{
    private static List<Product> _npcProducts = new List<Product>();
    private static List<Product> _playerProducts = new List<Product>();

    public static List<Product> NpcProducts => _npcProducts;
    public static List<Product> PlayerProducts => _playerProducts;

    //Ajouter l'item ou bien augmenter sa quantiter
    public void AddProduct(Product item)
    {
        var findItem = GetList(item.ProduitSeller);
        var exitingProduct = findItem.FirstOrDefault(p => p.ProduitName == item.ProduitName);

        if (exitingProduct != null)
        {
            exitingProduct.Quantity++;
        }
        else
        {
            findItem.Add(item);
        }
    }

    //Suprrimer l'item de la list
    public void RemoveProduct(Product item)
    {
        var itemList = GetList(item.ProduitSeller);
        itemList.Remove(item);
    }

    //Obtenir la list ou ce trouve l'item
    private List<Product> GetList(ProductType productType)
    {
        return productType == ProductType.Player ? PlayerProducts : NpcProducts;
    }
}

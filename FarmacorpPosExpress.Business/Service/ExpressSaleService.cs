
using FarmacorpPosExpress.Data;
using FarmacorpPosExpress.Models.ERP;
using FarmacorpPosExpress.Models.Express;

namespace FarmacorpPosExpress.Business.Service;

public class ExpressSaleService
{
    private UnitOfWork _unit;
    private int businessLogic;

    public ExpressSaleService(UnitOfWork unit, int businessLogic = 0)
    {
        _unit = unit;
        this.businessLogic = businessLogic;
    }

    public bool MakeSale(string client, int id, int quantity) {

        var product = _unit.ErpProductRepository.GetById(id);

        if (product != null && product.Stock >= quantity)
        {

            double salePrice = product.Cost;

            if (product.ExpProduct.ProductsCategories.Count == 1)
            {
                salePrice *= CalculateSalePrice(); 
            }

            double total = salePrice * quantity;

            if (businessLogic == 1 && product.Stock - quantity < 10) return false;

            ExpressSale newSale = new ExpressSale
            {
                Date = DateTime.Now,
                Client = client,
                UniqueProduct = product.UniqueCode,
                Quantity = quantity,
                Price = product.ExpProduct.Price,
                Discount = salePrice,
                Total = total,
                ExpProductId = product.ExpProductId
            };


            product.Stock -= quantity;


            _unit.ExpressSaleRepository.AddExpressSale(newSale);
            _unit.ErpProductRepository.UptadeErpProduct(product);
            _unit.Save();

            return true;
        }

        return false;
    }

    private double CalculateSalePrice()
    {
        return businessLogic == 0 ? 0.7 : 0.9;
    }
}

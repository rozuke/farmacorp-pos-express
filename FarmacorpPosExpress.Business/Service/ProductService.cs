using FarmacorpPosExpress.Data;
using FarmacorpPosExpress.Models.ERP;
using FarmacorpPosExpress.Models.Express;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmacorpPosExpress.Business.Service;

public class ProductService
{
    private UnitOfWork _unit;
    private int businessLogic;

    public ProductService(UnitOfWork unitOfWork, int businessLogic = 0)
    {
        _unit = unitOfWork;
        this.businessLogic = businessLogic;
    }
    public void SaveProduct(string name, double cost, DateTime expirationDate, string observations, int type, int stock)
    {
        string uniqueCode = GenerateUniqueCode();
        double price = CalculateProductPrice(cost);

        ExpProduct expProduct = new ExpProduct {
            Name = name,
            Price = price,
            Active = true,
            ExpirationDate = expirationDate,
            Observations = observations,
            ProductTypeId = type,
        };
        ErpProduct erpProduct = new ErpProduct {
            Cost = cost,
            UniqueCode = uniqueCode,
            RegistrationDate = DateTime.Now,
            ExpProduct = expProduct,
            Stock = stock
        };
        BarCode barCode = new BarCode {
            UniqueCode = uniqueCode,
            Active = true,
            Product = expProduct
        };

        _unit.ExpProductRepository.AddExpProduct(expProduct);
        _unit.ErpProductRepository.AddErpProduct(erpProduct);
        _unit.BarCodeRepository.AddBarCode(barCode);
        _unit.Save();

    }

    public List<ExpProduct> GetAll()
    {

        return _unit.ExpProductRepository.GetAll();
    }

    public List<ProductType> GetProductTypes()
    {
        return _unit.ProductTypeRepository.GetAll();
    }

    private double CalculateProductPrice(double cost) {
        return businessLogic == 0 ? cost * 1.5 : cost * 1.8;
    }
    private string GenerateUniqueCode()
    {
        return Guid.NewGuid().ToString().Substring(0, 8);
    }

    
}

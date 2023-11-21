using FarmacorpPosExpress.Data.RepositoryInterface;
using FarmacorpPosExpress.Models.ERP;
using Microsoft.EntityFrameworkCore;

namespace FarmacorpPosExpress.Data.Repository;

public class ErpProductRepository : IErpProductRepository
{
    private DbContext _dbContext;

    public ErpProductRepository(DbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void AddErpProduct(ErpProduct product)
    {
        _dbContext.Set<ErpProduct>().Add(product);
    }

    public ErpProduct GetById(int id)
    {
        return _dbContext.Set<ErpProduct>().Find(id);
    }

    public void UptadeErpProduct(ErpProduct newProduct)
    {
        var product = GetById(newProduct.ErpProductId);
        if (product != null)
        {
            product.ErpProductId = newProduct.ErpProductId;
            product.Cost = newProduct.Cost;
            product.RegistrationDate = newProduct.RegistrationDate;
            product.Stock = newProduct.Stock;

            AddErpProduct(product);

        }
    }
}

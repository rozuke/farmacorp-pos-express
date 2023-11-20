using FarmacorpPosExpress.Data.Repository;
using FarmacorpPosExpress.Models.ERP;
using Microsoft.EntityFrameworkCore;

namespace FarmacorpPosExpress.Data;

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
}

using FarmacorpPosExpress.Data.RepositoryInterface;
using FarmacorpPosExpress.Models.Express;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmacorpPosExpress.Data.Repository;

public class ProductTypeRepository : IProductTypeRepository
{
    private DbContext _dbContext;

    public ProductTypeRepository(DbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void AddProductType(ProductType productType)
    {
        _dbContext.Set<ProductType>().Add(productType);
    }

    public List<ProductType> GetAll()
    {
        return _dbContext.Set<ProductType>().ToList();
    }

    public ProductType GetById(int id)
    {
        return _dbContext.Set<ProductType>().Find(id);
    }
}

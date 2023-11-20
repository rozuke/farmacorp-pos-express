using FarmacorpPosExpress.Data.Repository;
using FarmacorpPosExpress.Models.Express;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmacorpPosExpress.Data;

public class ProductTypeRepository : IProductTypeRepository
{
    private DbContext _dbContext;
    public void AddProductType(ProductType productType)
    {
        _dbContext.Set<ProductType>().Add(productType);
    }

    public ProductType GetById(int id)
    {
        return _dbContext.Set<ProductType>().Find(id);
    }
}

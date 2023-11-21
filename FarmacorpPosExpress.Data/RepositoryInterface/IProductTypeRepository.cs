using FarmacorpPosExpress.Models.Express;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmacorpPosExpress.Data.RepositoryInterface;

public interface IProductTypeRepository
{
    ProductType GetById(int id);
    List<ProductType> GetAll();
    void AddProductType(ProductType productType);
}

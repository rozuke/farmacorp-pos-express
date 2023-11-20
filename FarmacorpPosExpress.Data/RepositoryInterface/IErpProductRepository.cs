using FarmacorpPosExpress.Models.ERP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FarmacorpPosExpress.Data.RepositoryInterface;

public interface IErpProductRepository
{
    ErpProduct GetById(int id);
    void AddErpProduct(ErpProduct product);
}

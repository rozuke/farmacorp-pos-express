using FarmacorpPosExpress.Models.ERP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FarmacorpPosExpress.Data.Repository;

public interface IErpProduct
{
    ErpProduct GetById(int id);
    void AddErpProduct(ErpProduct product);
}

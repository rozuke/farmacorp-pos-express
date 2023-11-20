using FarmacorpPosExpress.Models.ERP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmacorpPosExpress.Data.Repository;

public interface IBarCodeRepository
{
    BarCode GetById(int id);
    void AddBarCode(BarCode barCode);
}

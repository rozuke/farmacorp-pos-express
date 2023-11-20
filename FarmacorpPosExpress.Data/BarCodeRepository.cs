using FarmacorpPosExpress.Data.Repository;
using FarmacorpPosExpress.Models.ERP;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmacorpPosExpress.Data;

public class BarCodeRepository : IBarCodeRepository

{
    private DbContext _dbContext;

    public BarCodeRepository (DbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public void AddBarCode(BarCode barCode)
    {
        _dbContext.Set<BarCode>().Add(barCode);
    }

    public BarCode GetById(int id)
    {
        return _dbContext.Set<BarCode>().Find(id);
    }
}

using FarmacorpPosExpress.Data.Repository;
using FarmacorpPosExpress.Models.Express;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmacorpPosExpress.Data;

public class ExpressSaleRepository : IExpressSaleRepository
{

    private DbContext _dbContext;

    public ExpressSaleRepository (DbContext dbContext)
    {
        _dbContext = dbContext;
    }


    public void AddExpressSale(ExpressSale entity)
    {
        _dbContext.Set<ExpressSale>().Add(entity);
    }

    public ExpressSale GetById(int id)
    {
        return _dbContext.Set<ExpressSale>().Find(id);
    }
}

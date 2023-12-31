﻿using FarmacorpPosExpress.Data.RepositoryInterface;
using FarmacorpPosExpress.Models.Express;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmacorpPosExpress.Data.Repository;

public class ExpProductRepository : IExpProductRepository
{
    private DbContext _dbContext;

    public ExpProductRepository(DbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public void AddExpProduct(ExpProduct expProduct)
    {
        _dbContext.Set<ExpProduct>().Add(expProduct);
    }

    public List<ExpProduct> GetAll()
    {
        return _dbContext.Set<ExpProduct>().ToList(); 
    }

    public ExpProduct GetById(int id)
    {
        return _dbContext.Set<ExpProduct>().Find(id);
    }
}

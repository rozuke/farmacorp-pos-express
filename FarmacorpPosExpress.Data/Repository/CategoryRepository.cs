using FarmacorpPosExpress.Data.RepositoryInterface;
using FarmacorpPosExpress.Models.Express;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmacorpPosExpress.Data.Repository;

public class CategoryRepository : ICategoryRepository
{
    private DbContext _dbContext;

    public CategoryRepository(DbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public void AddCategory(Category category)
    {
        _dbContext.Set<Category>().Add(category);
    }

    public Category GetById(int id)
    {
        return _dbContext.Set<Category>().Find(id);
    }
}

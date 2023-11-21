using FarmacorpPosExpress.Models.Express;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmacorpPosExpress.Data.RepositoryInterface;
public interface ICategoryRepository
{
    Category GetById(int id);

    List<Category> GetAll();
    void AddCategory(Category category);
}

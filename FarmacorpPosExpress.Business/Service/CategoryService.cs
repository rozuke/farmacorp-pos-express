using FarmacorpPosExpress.Data;
using FarmacorpPosExpress.Models.Express;


namespace FarmacorpPosExpress.Business.Service;

public class CategoryService
{
    private UnitOfWork _unit;

    public CategoryService(UnitOfWork unit)
    {
        _unit = unit;
    }

    public void SaveCategory(string description)
    {
        Category category = new Category {
            Description = description,
            Active = true
        };
        _unit.CategoryRepository.AddCategory(category);
        _unit.Save();
    }

    public List<Category> GetAllCategories()
    {
        return _unit.CategoryRepository.GetAll();
    }

    public void DeleteCategory(int id) {
        Category category = _unit.CategoryRepository.GetById(id);

        if (category != null)
        {
            
        }
    }
}

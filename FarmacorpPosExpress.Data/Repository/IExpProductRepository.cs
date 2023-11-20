using FarmacorpPosExpress.Models.Express;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmacorpPosExpress.Data.Repository;
public interface IExpProductRepository
{
    ExpProduct GetById(int id);
    void AddExpProduct(ExpProduct expProduct);
}

using FarmacorpPosExpress.Models.Express;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmacorpPosExpress.Models.ERP;
public class ErpProduct
{

    public int ErpProductId { get; set; }
    public double Cost { get; set; }
    public string UniqueCode { get; set; }
    public DateTime RegistrationDate { get; set; }

    public int ExpProductId { get; set; }
    public virtual ExpProduct ExpProduct { get; set; }

}
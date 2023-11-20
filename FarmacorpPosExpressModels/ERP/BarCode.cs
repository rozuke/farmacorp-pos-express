using FarmacorpPosExpress.Models.Express;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmacorpPosExpress.Models.ERP;
public class BarCode
{

    public int BarCodeId { get; set; }
    public string UniqueCode { get; set; }
    public bool Active { get; set; }

    public int ExpProductId { get; set; }
    public virtual ExpProduct Product { get; set; }
}

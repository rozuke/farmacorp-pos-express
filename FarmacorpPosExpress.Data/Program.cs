using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmacorpPosExpress.Data;

public class Program
{
    static void Main(string[] args)
    {
        
        using (var dbContext = new FarmacorpDbContext())
        {
            try
            {

                var data = dbContext.Categories.ToList();
                Console.WriteLine(data.ToString());
                Console.WriteLine("DB Created");
            } catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}



using ConsoleTableExt;
using FarmacorpPosExpress.Business.Service;
using FarmacorpPosExpress.Data;
using FarmacorpPosExpress.Models.Express;
using System.Globalization;

public class Program
{

    public static void Main()
    {
        var dbContext = new FarmacorpDbContext();
        var unitOfWork = new UnitOfWork(dbContext);

        Console.WriteLine("Bienvenido a Farmacorp POS Express");
        

        int choice;
        Mode bussinesLogic = Mode.BASE;
        do
        {
            Console.WriteLine($"Sistema Ejecutado en modo : {bussinesLogic}");
            Console.WriteLine("Seleccione una opción:");
            ShowMenu();
            choice = GetUserSelection();

            switch (choice)
            {
                case 1:
                    MakeSale(unitOfWork, bussinesLogic);
                    break;
                case 2:
                    RegisterProduct(unitOfWork, bussinesLogic);
                    break;
                case 3:
                    bussinesLogic = ChangeBussinesLogic();
                    break;
                case 0:
                    Console.WriteLine("Saliendo del programa...");
                    break;
                default:
                    Console.WriteLine("Opción inválida. Por favor, elija una opción válida.");
                    break;
            }
        } while (choice != 0);
    }

    private static Mode ChangeBussinesLogic()
    {
        Console.WriteLine("\n1. Elige el modelo de negocio");
        Console.WriteLine("1. Modo Base");
        Console.WriteLine("2. Modo GanaMax");
        int choice;
        do
        {
            choice = ParseNumber();

            return choice == 1 ? Mode.BASE : Mode.GANAMAX;
        } while (true);
    }

    private static void ShowMenu()
    {
        Console.WriteLine("\n1. Realizar una Venta");
        Console.WriteLine("2. Registrar un Producto");
        Console.WriteLine("3. Cambiar Modo Del Sistema");
        Console.WriteLine("0. Salir");
    }

    private static int GetUserSelection()
    {
        Console.Write("\nIngrese su selección: ");
        return ParseNumber();
    }

    private static int ParseNumber()
    {
        int choice;
        while (!int.TryParse(Console.ReadLine(), out choice))
        {
            Console.Write("Entrada inválida. Ingrese un número: ");
        }
        return choice;
    }

    private static double ParseNumberToDouble()
    {
        double choice;
        while (!double.TryParse(Console.ReadLine(), out choice))
        {
            Console.Write("Entrada inválida. Ingrese un número: ");
        }
        return choice;
    }

    private static DateTime ParseDateTime()
    {
        string inputDate = Console.ReadLine();
        DateTime date;
        while (!DateTime.TryParseExact(inputDate, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
        {
            Console.Write("Formato de fecha inválido. Ingrese la fecha en el formato correcto (YYYY-MM-DD): ");
            inputDate = Console.ReadLine();
        }
        return date;
    }


    private static void RegisterProduct(UnitOfWork unit, Mode bussinesLogic)
    {
        Console.WriteLine("\n--- Registrando un Producto ---");

        ProductService productService = new ProductService(unit, (int) bussinesLogic);
        var types = productService.GetProductTypes();
        ShowTypes(types);


        Console.Write("Ingrese el Nombre del Producto: ");
        string productName = Console.ReadLine();

        Console.Write("Ingrese el Costo del Producto: ");
        double cost = ParseNumberToDouble();

        Console.Write("Ingrese la fecha de vencimiento (YYYY-MM-DD): ");
        DateTime date = ParseDateTime();

        Console.Write("Ingrese alguna observacion del producto: ");
        string observation = Console.ReadLine();

        Console.Write("Ingrese el id del tipo de producto: ");
        int type = ParseNumber();

        Console.Write("Ingrese el stock del producto: ");
        int stock = ParseNumber();

        productService.SaveProduct(productName, cost, date, observation, type, stock);
    }

    private static void MakeSale(UnitOfWork unit, Mode bussinesLogic)
    {
        Console.WriteLine("\n--- Realizando una Venta ---\n");

        ProductService productService = new ProductService(unit, (int) bussinesLogic);
        ExpressSaleService saleService = new ExpressSaleService(unit, (int) bussinesLogic);
        var products = productService.GetAll();
        ShowProducts(products);

        Console.Write("Ingrese el id del Producto: ");
        int id = ParseNumber();

        Console.Write("Ingrese la Cantidad: ");
        int quantity = ParseNumber();
        

        Console.Write("Ingrese el Nombre del Cliente: ");
        string client = Console.ReadLine();



        bool ventaExitosa = saleService.MakeSale(client, id, quantity);

        if (ventaExitosa)
        {
            Console.WriteLine("¡Venta completada con éxito!");
        }
        else
        {
            Console.WriteLine("La venta no pudo realizarse. Verifique la disponibilidad y los detalles del producto.");
        }
    }

    private static void ShowTypes(List<ProductType> types)
    {
        if (types != null)
        {
            ConsoleTableBuilder.From(types).ExportAndWriteLine();
        }

    }
    private static void ShowProducts(List<ExpProduct> products)
    {
        if (products != null )
        {
            ConsoleTableBuilder.From(products).ExportAndWriteLine();
        }

    }

}
public enum Mode
{
    BASE,
    GANAMAX
}

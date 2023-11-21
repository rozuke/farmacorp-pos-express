using FarmacorpPosExpress.Data.Repository;
using FarmacorpPosExpress.Data.RepositoryInterface;


namespace FarmacorpPosExpress.Data;

public class UnitOfWork : IDisposable
{
    private readonly FarmacorpDbContext _context;

    public IBarCodeRepository BarCodeRepository { get; }
    public IErpProductRepository ErpProductRepository { get; }
    public ICategoryRepository CategoryRepository { get; }
    public IExpProductRepository ExpProductRepository { get; }
    public IExpressSaleRepository ExpressSaleRepository { get; }
    public IProductTypeRepository ProductTypeRepository { get; }

    public UnitOfWork(FarmacorpDbContext context)
    {
        _context = context;
        BarCodeRepository = new BarCodeRepository(_context);
        ErpProductRepository = new ErpProductRepository(_context);
        CategoryRepository = new CategoryRepository(_context);
        ExpProductRepository = new ExpProductRepository(_context);
        ExpressSaleRepository = new ExpressSaleRepository(_context);
        ProductTypeRepository = new ProductTypeRepository(_context);
    }

    

    public void Save() => _context.SaveChanges();

    public void Dispose() => _context.Dispose();
}

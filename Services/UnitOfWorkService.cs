using System.Threading.Tasks;
using UserPermissionsManagement.Contexts;
namespace UserPermissionsManagement.Services;

public class UnitOfWork : IUnitOfWorkService
{
    // private readonly UserPermissionsContext _context;
    // private bool _transactionStarted;

    // public UnitOfWork(UserPermissionsContext context)
    // {
    //     _context = context;
    //     _transactionStarted = false;
    // }

    // public async Task BeginTransactionAsync()
    // {
    //     if (!_transactionStarted)
    //     {
    //         await _context.Database.BeginTransactionAsync();
    //         _transactionStarted = true;
    //     }
    // }

    // public async Task CommitAsync()
    // {
    //     if (_transactionStarted)
    //     {
    //         Console.WriteLine("CommitAsync");
    //         await _context.SaveChangesAsync();
    //         await _context.Database.CommitTransactionAsync();
    //         _transactionStarted = false;
    //     }else {
    //         Console.WriteLine("No hay transacción iniciada");
    //     }
    // }

    // public async Task RollbackAsync()
    // {
    //     if (_transactionStarted)
    //     {
    //         await _context.Database.RollbackTransactionAsync();
    //         _transactionStarted = false;
    //     }
    // }
}

public interface IUnitOfWorkService
{
    // Task BeginTransactionAsync();
    // Task CommitAsync();
    // Task RollbackAsync();
}
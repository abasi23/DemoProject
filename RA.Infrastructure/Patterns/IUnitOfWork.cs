
namespace RA.Infrastructure.Patterns
{
    public interface IUnitOfWork : IDisposable
    {
        Task SaveChangesAsync();
    }
}

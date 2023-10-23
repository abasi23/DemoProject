using RA.Infrastructure.Database;
using RA.Infrastructure.Patterns;

namespace RA.Domain.Patterns
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RAContext context;

        public UnitOfWork(RAContext context)
        {
            this.context = context;
        }
        public void Dispose()
        {
            context.Dispose();
        }

        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}

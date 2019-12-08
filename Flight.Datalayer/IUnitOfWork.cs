using Microsoft.EntityFrameworkCore;

namespace Flight.DataLayer
{
    public interface IUnitOfWork<out TContext> where TContext : DbContext
    {
        TContext Context { get; }
        void Save();
    }
}
using Microsoft.EntityFrameworkCore;

namespace Flight.DataLayer
{
    public class UnitOfWork<TContext> : IUnitOfWork<TContext>
        where TContext : DbContext, new()
    {
        public UnitOfWork()
        {
            Context = new TContext();
        }
        public TContext Context { get; }

        public void Save()
        {
            Context.SaveChanges();
        }
    }
}
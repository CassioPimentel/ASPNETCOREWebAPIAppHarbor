using Microsoft.EntityFrameworkCore;

namespace ASPNETCOREWebAPIAppHarbor.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }

        public DbSet<Marca> Marca { get; set; }
        public DbSet<ModeloCarro> ModeloCarro { get; set; }
    }
}

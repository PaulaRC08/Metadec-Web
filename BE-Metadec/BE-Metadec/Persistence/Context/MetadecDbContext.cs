using BE_Metadec.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BE_Metadec.Persistence.Context
{
    public class MetadecDbContext: DbContext
    {
        public DbSet<MD_Usuario> Usuario { get; set; }
        public DbSet<MD_Pais> Pais { get; set; }
        public MetadecDbContext (DbContextOptions<MetadecDbContext> options):base(options)
        {

        }

    }
}

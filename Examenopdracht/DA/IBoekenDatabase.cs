using Model;
using System;
using System.Data.Entity;
using System.Threading.Tasks;

namespace DA
{
    public  interface IBoekenDatabase
    {
        DbSet<Boek> Boeken { get; set; }
        DbSet<Genre> Genres { get; set; }

        Task<Int32> SaveChangesAsync();
    }
}

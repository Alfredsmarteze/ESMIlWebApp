
using Microsoft.EntityFrameworkCore;
using DataStructure.Entites;

namespace DataContextStructure
{
    public class ESMContext : DbContext
    {
        public ESMContext(DbContextOptions<ESMContext> option) : base(option)
        {
           // var contextOptions = new DbContextOptionsBuilder<ESMContext>().("Data:ConnectionString:Connection").Options;


           // using var context = new ESMContext(contextOptions);

        }
        public DbSet<PrayerUnit> prayerUnit { get; set; }




    }
}
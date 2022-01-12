using Microsoft.EntityFrameworkCore;
using DataStructure.Entites;
namespace DataContextStructure
{
        public class ESMContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)=>optionsBuilder.UseSqlServer(@"Server=DESKTOP-GV6K069;Database=ESMPSDb;Trusted_Connection=True"); 
        
        public DbSet<PrayerUnit> prayerUnit { get; set; }


          

    }
}
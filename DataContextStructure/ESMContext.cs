using Microsoft.EntityFrameworkCore;
using DataStructure.Entites;
using Microsoft.Extensions.Configuration;

namespace DataContextStructure
{
    public class ESMContext : DbContext
    {
        public ESMContext(DbContextOptions<ESMContext> options) : base(options)
        {
            // var contextOptions = new DbContextOptionsBuilder<ESMContext>().("Data:ConnectionString:Connection").Options;


            // using var context = new ESMContext(contextOptions);

        }


        public DbSet<PrayerUnit> prayerUnit { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("Connection");
            optionsBuilder.UseSqlServer(connectionString);
        }

    }
}
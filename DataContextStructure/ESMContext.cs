using Microsoft.EntityFrameworkCore;
using DataStructure.Entites;
using Microsoft.Extensions.Configuration;
using DataStructure;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace DataContextStructure
{
    public class ESMContext :IdentityDbContext<ApplicationUser>
    {
        public ESMContext(DbContextOptions<ESMContext> options) : base(options)
        {
            // var contextOptions = new DbContextOptionsBuilder<ESMContext>().("Data:ConnectionString:Connection").Options;


            // using var context = new ESMContext(contextOptions);

        }
        public DbSet<FirstTimer> firstTimer { get; set; }
        public DbSet<LoginInfo> loginInfo { get; set; }
        public DbSet<Register> register { get; set; }
        public DbSet<TransportUnit> transportUnit { get; set; }
        public DbSet<ChoralUnit> choralUnit { get; set; }
        public DbSet<DmeUnit> dmeUnit { get; set; }
        public DbSet<PublicityAndEditorialUnit> publicityAndEditorialUnit { get; set; }
        public DbSet<TechnicalUnit> technicalUnit { get; set; }
        public DbSet<UsheringUnit> usheringUnit { get; set; }
        public DbSet<WelfareUnit> welfareUnit { get; set; }
        public DbSet<BibleStudyUnit> bibleStudyUnit { get; set; }  
        public DbSet<PrayerUnit> prayerUnit { get; set; }
        public DbSet<State> state { get; set; }
        public DbSet<Lga> lga { get; set; }

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
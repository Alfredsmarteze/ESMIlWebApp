using Microsoft.EntityFrameworkCore;
using DataStructure.Entites;
using Microsoft.Extensions.Configuration;
using DataStructure;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Reflection.Emit;
using System.Reflection.Metadata;

namespace DataContextStructure
{
    public class ESMContext : IdentityDbContext<ApplicationUser>
    {
        public ESMContext(DbContextOptions<ESMContext> options) : base(options)
        {
            // var contextOptions = new DbContextOptionsBuilder<ESMContext>().("Data:ConnectionString:Connection").Options;


            // using var context = new ESMContext(contextOptions);
        }
        public DbSet<EventImage> eventImage { get; set; }
        public DbSet<Announcement> announcement { get; set; }
        public DbSet<PresidentCharge> presidentCharge { get; set; }
        public DbSet<PastVicePresident> pastVicePresident { get; set; }
        public DbSet<PastOrganizingSecretary> pastOrganizingSecretary { get; set; }   
        public DbSet<PastFinancialSecretary> pastFinancialSecretary { get; set; }
        public DbSet<PastChoralSecretary> pastChoralSecretary { get; set; }
        public DbSet<GeneralMember> generalMember { get; set; }
        public DbSet<PastBrotherCordinator> brotherCordinator { get; set; }
        public DbSet<PastSisterCordinator> sisterCordinator { get; set; }
        public DbSet<TestimonyNumber> numberTestimony { get; set; }
        public DbSet<Testimony> testimony { get; set; }
        public DbSet<ProgramTable> programTable { get; set; }
        public DbSet<PastDramaUnitCordinator> pastDramaUnitCordinator { get; set; }
        public DbSet<PastTreasurer> pastTreasurer { get; set; }
        public DbSet<PastSecretary> pastSecretary { get; set; }
        public DbSet<PastPresident> pastPresident { get; set; }
        public DbSet<PastPublicityUnitCordinator> pastPublicityUnitCordinator     { get; set; }
        public DbSet<PastPrayerUnitCordinator>  pastPrayerUnitCordinator   { get; set; }
        public DbSet<PastWelfareUnitCordinator>  pastWelfareUnitCordinator   { get; set; }
        public DbSet<PastTransportUnitCordinator>  pastTransportUnitCordinator  { get; set; }
        public DbSet<PastUsheringUnitCordinator> pastUsheringUnitCordinator   { get; set; }
        public DbSet<PastTechnicalUnitCordinator> pastTechnicalUnitCordinator  { get; set; }
        public DbSet<PastChoralUnitCordinator>  pastChoralUnitCordinator { get; set; }
        public DbSet<PastDMECordinator> pastDMECordinator { get; set; }
        public DbSet<PastBibleStudyCordinator> pastBibleStudyCordinators { get; set; }
        public DbSet<ESMAF> eSMAF { get; set; }
        public DbSet<PastExecutive> pastExecutive { get; set; }
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



        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //builder
            //.Entity<ESMAF>()
            //.HasOne(e => e.PastExcos)
            //.WithOne(e => e.ESMAF).IsRequired()
            //.HasForeignKey<PastExecutive>(s => s.EsmafId).IsRequired();//.OnDelete(DeleteBehavior.NoAction);

            //builder
            //.Entity<PastExecutive>()
            //.HasOne(e => e.ESMAF)
            //.WithOne(e => e.PastExcos)
            //.HasForeignKey<ESMAF>(s => s.PastId);
        }



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
using LiteDBProject.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;


namespace LiteDBProject.Data.SQLite
{
    public class PremixContext : DbContext
    {

        public DbSet<Premix> Premixes { get; set; }
        public DbSet<Vitamin> Vitamins { get; set; }
        public DbSet<Developer> Developers { get; set; }

        public DbSet<PremixVitamin> PremixVitamins { get; set; }

        public string DBPath { get; }


        public PremixContext(DbContextOptions<PremixContext> options) : base (options)
        {
            //DBPath = @"data source=c:\Tools\SQLiteDBs\resinternal.db";

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // You don't actually ever need to call this
            //optionsBuilder.UseSqlite(DBPath);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vitamin>().Property(x => x.VitaminId).ValueGeneratedOnAdd();


            modelBuilder.Entity<Vitamin>().ToTable("Vitamin").HasData(
                new Vitamin[]
                {
                    new Vitamin { VitaminId = 1, Title = "A", Rastvor = "rastvor" },
                    new Vitamin { VitaminId = 2,Title = "B", Rastvor = "rastvor" },
                    new Vitamin { VitaminId = 3, Title = "C", Rastvor = "rastvor" }
                }
                );


            //modelBuilder.Entity<Developer>().Property(x => x.DeveloperId).ValueGeneratedOnAdd();
            //modelBuilder.Entity<Developer>().ToTable("Developer").HasIndex(x => x.Name).IsUnique();
            modelBuilder.Entity<Developer>().ToTable("Developer").HasData(new Developer[] {
                new Developer () { DeveloperId = 1,  Name = "Terezia", Country = "England" },
                new Developer () { DeveloperId = 2, Name = "Resurs", Country = "Russia" }
                }
                );
            
            modelBuilder.Entity<Premix>().ToTable("Premix").HasKey(x => x.PremixId);// ;//.HasMany(d => d.developerId).WithOne(b => b.devcode).HasForeignKey(b => b.developerId);   
            modelBuilder.Entity<Premix>().HasOne(d => d.Developer);
            //modelBuilder.Entity<Premix>().HasMany(v => v.PremixVitamins);

            //modelBuilder.Entity<PremixVitamin>().HasKey(pv => new { pv.PremixId, pv.VitaminId});


            //        modelBuilder.Entity<Book_Author>()
            //.HasOne(b => b.Book)
            //.WithMany(ba => ba.Book_Authors)
            //.HasForeignKey(bi => bi.BookId);

            //        modelBuilder.Entity<Book_Author>()
            //          .HasOne(b => b.Author)
            //          .WithMany(ba => ba.Book_Authors)
            //          .HasForeignKey(bi => bi.AuthorId);
            modelBuilder.Entity<PremixVitamin>()
                     .HasOne(p => p.Premix)
                     .WithMany(pv => pv.PremixVitamins)
                     .HasForeignKey(p => p.PremixId);

            modelBuilder.Entity<PremixVitamin>()
              .HasOne(v => v.Vitamin)
              .WithMany(pv => pv.PremixVitamins)
              .HasForeignKey(bi => bi.VitaminId);


            modelBuilder.Entity<Premix>().HasData(new Premix
            {
                PremixId = 1,
                Title = "Premix 1",
                Tu = "tu 1",
                Age = "small",
                Vid = "rastvor",
                DeveloperId = 1
            });
            

        }



    }
}

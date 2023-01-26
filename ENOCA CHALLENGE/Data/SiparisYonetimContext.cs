using ENOCA_CHALLENGE.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using System.Runtime.Intrinsics.X86;

namespace ENOCA_CHALLENGE.Data
{
    public class SiparisYonetimContext : DbContext
    {
        public DbSet<Firma> Firmalar { get; set; }
        public DbSet<Urun> Urunler { get; set; }
        public DbSet<Siparis> Siparisler { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-6KUAN1F\\SQLEXPRESS;Database=EnocaSiparisYonetim;Integrated Security=True;TrustServerCertificate=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Firma>()
                .HasMany(f => f.Siparisler)
                .WithOne(s => s.Firma)
                .HasForeignKey(s => s.FirmaId)
                .OnDelete(DeleteBehavior.Restrict); 
            modelBuilder.Entity<Firma>()
                .HasMany(f => f.Urunler)
                .WithOne(u => u.Firma)
                .HasForeignKey(u => u.FirmaId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Urun>()
                .HasMany(u => u.Siparisler)
                .WithOne(s => s.Urun)
                .HasForeignKey(s => s.UrunId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }

}

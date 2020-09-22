using dll_pet_shop;
using dll_pet_shop.Animais;
using dll_pet_shop.Join;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop
{
    public class PetShopContext : DbContext
    {
        public DbSet<Cliente> Clientes { set; get; }
        public DbSet<Gato> Gatos { set; get; }
        public DbSet<Cachorro> Cachorros { set; get; }
        public DbSet<Brinquedo> Brinquedos { set; get; }
        public DbSet<Alimento> Alimentos { set; get; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PetShop.PetShopContex;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(tbl =>
            {
                tbl.ToTable("Clientes");
                tbl.HasKey(x => x.Id);
                tbl.Property(x => x.Nome).HasMaxLength(100);
                tbl.Property(x => x.CPF).HasMaxLength(15);
            });
            modelBuilder.Entity<Gato>(tbl =>
            {
                tbl.ToTable("Gatos");
                tbl.HasKey(g => g.Id);
                tbl.Property(g => g.Nome).HasMaxLength(20);
            });
            modelBuilder.Entity<Cachorro>(tbl =>
            {
                tbl.ToTable("Cachorro");
                tbl.HasKey(c => c.Id);
                tbl.Property(c => c.Nome).HasMaxLength(20);
            });
            modelBuilder.Entity<Brinquedo>(tbl =>
            {
                tbl.ToTable("Brinquedos");
                tbl.HasKey(b => b.Id);
                tbl.Property(b => b.Descricao).HasMaxLength(100);
            });
            modelBuilder.Entity<Alimento>(tbl =>
            {
                tbl.ToTable("Alimentos");
                tbl.HasKey(b => b.Id);
                tbl.Property(b => b.Descricao).HasMaxLength(100);
            });
            modelBuilder.Entity<ClienteAlimento>(tbl => 
            {
                tbl.HasKey(ca => new { ca.ClienteId, ca.AlimentoId });
            });
            modelBuilder.Entity<ClienteBrinquedo>(tbl =>
            {
                tbl.HasKey(cb => new { cb.ClienteId, cb.BrinquedoId });
            });
        }
    }
}

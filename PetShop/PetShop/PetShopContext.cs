using dll_pet_shop;
using dll_pet_shop.Animais;
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
        public void ModelBuilder(ModelBuilder OnModelBuilder)
        {
        }

    }
}

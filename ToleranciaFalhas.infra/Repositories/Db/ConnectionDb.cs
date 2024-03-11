using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToleranciaFalhas.domain.Entities;
using ToleranciaFalhas.infra.Repositories.Db.Mapping;

namespace ToleranciaFalhas.infra.Repositories.Db
{
    public class ConnectionDb : DbContext
    {

        public ConnectionDb(DbContextOptions dboptions)
            :base(dboptions) { }


        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Venda> Compras { get; set; }
        public DbSet<ItemVenda> ItensVenda { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClienteMapping());
            modelBuilder.ApplyConfiguration(new ProdutoMapping());
            modelBuilder.ApplyConfiguration(new CompraMapping());
            modelBuilder.ApplyConfiguration(new ItemVendaMaping());
            modelBuilder.ApplyConfiguration(new ItemCarrinhoMapping());
        }

    }
}

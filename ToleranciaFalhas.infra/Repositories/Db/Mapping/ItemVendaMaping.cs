using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToleranciaFalhas.domain.Entities;

namespace ToleranciaFalhas.infra.Repositories.Db.Mapping
{
    internal class ItemVendaMaping : IEntityTypeConfiguration<ItemVenda>
    {
        public void Configure(EntityTypeBuilder<ItemVenda> builder)
        {
            builder.ToTable("item_venda");
            builder.HasKey(e => new { e.IdVenda, e.IdProduto });

            
            builder.Property(c => c.Quantidade).HasColumnName("quantidade");
            builder.Property(c => c.IdVenda).HasColumnName("id_compra");            
            builder.Property(c => c.IdProduto).HasColumnName("id_produto");
            builder.Property(c => c.ValorItem).HasColumnName("valor");
        }
    }
}

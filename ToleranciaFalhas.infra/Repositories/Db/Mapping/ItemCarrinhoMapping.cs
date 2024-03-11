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
    internal class ItemCarrinhoMapping : IEntityTypeConfiguration<ItemCarrinho>
    {
        public void Configure(EntityTypeBuilder<ItemCarrinho> builder)
        {
            builder.ToTable("item_carrinho");
            builder.HasKey(c => new { c.IdCliente, c.IdProduto });

            builder.Property(c => c.IdCliente).HasColumnName("id_cliente");
            builder.Property(c => c.IdProduto).HasColumnName("id_produto");

            builder.Property(c => c.Quantidade).HasColumnName("quantidade");
            
        }
    }
}

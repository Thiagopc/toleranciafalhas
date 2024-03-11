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
    internal class ProdutoMapping : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("produto");
            builder.HasKey(x => x.Id);

            builder.Property(c => c.Descricao).HasColumnName("descricao");
            builder.Property(c => c.QuantidadeEstoque).HasColumnName("quantidade");
            builder.Property(c => c.Nome).HasColumnName("nome");
            builder.Property(c => c.Id).HasColumnName("id");
            builder.Property(c => c.UrlImg).HasColumnName("url_img");
            builder.Property(c => c.Valor).HasColumnName("valor");
        }
    }
}

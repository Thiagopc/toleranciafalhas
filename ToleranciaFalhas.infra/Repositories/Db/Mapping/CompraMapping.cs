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
    internal class CompraMapping : IEntityTypeConfiguration<Venda>
    {
        public void Configure(EntityTypeBuilder<Venda> builder)
        {
            builder.ToTable("compra");
            builder.HasKey(c => c.Id);

            builder.Property(c => c.IdCliente).HasColumnName("id_cliente");
            builder.Property(c => c.Id).HasColumnName("id");
            builder.Property(c => c.DataHora).HasColumnName("data_hora");
            builder.Property(c => c.Valor).HasColumnName("valor");
        }
    }
}

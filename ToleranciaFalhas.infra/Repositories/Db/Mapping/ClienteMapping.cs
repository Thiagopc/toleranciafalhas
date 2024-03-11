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
    internal class ClienteMapping : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("cliente");
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id).HasColumnName("id");
            builder.Property(c => c.Nome).HasColumnName("nome");
            builder.Property(c => c.Password).HasColumnName("password");
            builder.Property(c => c.Email).HasColumnName("email");


            builder.HasOne(c => c.ItemCarrinho)
                .WithOne(c => c.Cliente)
                .HasPrincipalKey<Cliente>(c => c.Id);
                
                
                
                
                
            
        }
    }
}

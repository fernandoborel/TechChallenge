using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechChallenge.Domain.Entities;

namespace TechChallenge.Infra.Data.Mappings;

public class TechChallengeMapping : IEntityTypeConfiguration<Contato>
{
    public void Configure(EntityTypeBuilder<Contato> builder)
    {
        builder.HasKey(e => e.Id).HasName("PK__Contatos__3214EC07CC49FCF3");

        builder.Property(e => e.Ddd)
            .HasMaxLength(3)
            .IsUnicode(false)
            .IsFixedLength()
            .HasColumnName("DDD");
        builder.Property(e => e.Email).HasMaxLength(150);
        builder.Property(e => e.Nome).HasMaxLength(100);
        builder.Property(e => e.Telefone).HasMaxLength(20);
    }
}
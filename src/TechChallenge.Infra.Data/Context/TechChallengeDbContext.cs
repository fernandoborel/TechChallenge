using Microsoft.EntityFrameworkCore;
using TechChallenge.Domain.Entities;
using TechChallenge.Infra.Data.Mappings;

namespace TechChallenge.Infra.Data.Context;

public partial class TechChallengeDbContext : DbContext
{
    public TechChallengeDbContext(){}

    public TechChallengeDbContext(DbContextOptions<TechChallengeDbContext> options): base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new TechChallengeMapping());
    }

    public virtual DbSet<Contato> Contatos { get; set; }
}
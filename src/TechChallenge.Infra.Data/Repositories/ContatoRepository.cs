using TechChallenge.Domain.Entities;
using TechChallenge.Domain.Interfaces.Repositories;
using TechChallenge.Infra.Data.Context;

namespace TechChallenge.Infra.Data.Repositories;

public class ContatoRepository : BaseRepository<Contato>, IContatoRepository
{
    private readonly TechChallengeDbContext _context;

    public ContatoRepository(TechChallengeDbContext context) : base(context)
      =>  _context = context;
}
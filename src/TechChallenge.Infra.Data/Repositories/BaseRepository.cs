using TechChallenge.Domain.Core;
using TechChallenge.Infra.Data.Context;

namespace TechChallenge.Infra.Data.Repositories;

public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
{
    private readonly TechChallengeDbContext _context;

    public BaseRepository(TechChallengeDbContext context)
      =>  _context = context;

    public void Create(TEntity entity)
    {
        _context.Set<TEntity>().Add(entity);
        _context.SaveChanges();
    }

    public void Update(TEntity entity)
    {
        _context.Set<TEntity>().Update(entity);
        _context.SaveChanges();
    }

    public void Delete(TEntity entity)
    {
        _context.Set<TEntity>().Remove(entity);
        _context.SaveChanges();
    }

    public void Dispose()
        => _context.Dispose();

    public List<TEntity> GetAll()
        => _context.Set<TEntity>().ToList();

    public TEntity GetById(int id)
        => _context.Set<TEntity>().Find(id);
}
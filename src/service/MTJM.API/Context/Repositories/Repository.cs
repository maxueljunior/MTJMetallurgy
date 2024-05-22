using Microsoft.EntityFrameworkCore;
using MTJM.API.Models;

namespace MTJM.API.Context.Repositories;

public class Repository<T> : IRepository<T> where T : Base
{
    #region Properties
    private readonly AppDbContext _context;
    #endregion

    #region Constructors
    public Repository(AppDbContext context)
    {
        _context = context;
    }
    #endregion

    #region Methods
    public IQueryable<T> GetAll()
    {
        return _context.Set<T>().AsNoTracking();
    }

    public async Task<T> Create(T entity)
    {
        await _context.Set<T>().AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task Delete(int id)
    {
        var entity = await GetById(id);
        _context.Set<T>().Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task Edit(T entity)
    {
        _context.Set<T>().Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<T> GetById(int id)
    {
        return await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
    }
    #endregion
}

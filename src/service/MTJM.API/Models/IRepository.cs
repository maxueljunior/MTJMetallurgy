namespace MTJM.API.Models;

public interface IRepository<T> where T : class
{
    Task<T> Create(T entity);
    Task<T> GetById(int id);
    IQueryable<T> GetAll();
    Task Edit(T entity);
    Task Delete(int id);
}

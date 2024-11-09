using Microsoft.EntityFrameworkCore;
using User_Management_System.Data.Context;
using User_Management_System.Data.Contracts;

namespace User_Management_System.Data.Repositories;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
{
    private readonly ApplicationDbContext _context;

    public GenericRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    #region NormalMethods

    public IEnumerable<TEntity> GetAll()
    {
        return _context.Set<TEntity>().ToList();
    }

    public TEntity GetByID(int id)
    {
        return _context.Set<TEntity>().Find(id);
    }

    public void Insert(TEntity entity)
    {
        _context.Set<TEntity>().Add(entity);
        SaveChanges();
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }

    public void Update(TEntity entity)
    {
        _context.Set<TEntity>().Entry(entity).State = EntityState.Modified;
        SaveChanges();
    }

    public void Delete(object Id)
    {
        var EntityToDelete = _context.Set<TEntity>().Find(Id);
        _context.Set<TEntity>().Remove(EntityToDelete);
        SaveChanges();
    }

    #endregion
}
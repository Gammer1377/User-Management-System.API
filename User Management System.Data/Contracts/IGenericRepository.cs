namespace User_Management_System.Data.Contracts;

public interface IGenericRepository<TEntity> where TEntity : class
{
    #region NormalMethods

    IEnumerable<TEntity> GetAll();
    TEntity GetByID(int id);
    void Insert(TEntity entity);
    void Delete(object Id);
    void Update(TEntity entity);
    void SaveChanges();

    #endregion

    #region AsyncMethods

    Task<TEntity> GetAsync(int Id);
    Task<IReadOnlyList<TEntity>> GetAllAsync();
    Task<TEntity> InsertAsync(TEntity entity);
    Task UpdateAsync(TEntity entity);
    Task DeleteAsync(TEntity entity);
    Task<bool> ExistAsync(int Id);
    Task SaveChangesAsync();

    #endregion
}
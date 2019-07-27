namespace GoOut.Data.Common.Repositories
{
    using Models;
    using System.Linq;

    public interface IDeletableEntityRepository<TEntity> : IRepository<TEntity> where TEntity : class, IDeletableEntity
    {
        IQueryable<TEntity> AllWithDeleted();

        IQueryable<TEntity> AllAsNoTrackingWithDeleted();
        
        void HardDelete(TEntity entity);

        void Undelete(TEntity entity);
    }
}
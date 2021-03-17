namespace www.veinid365.cn.Data.IRepositories
{
    public interface IRepositoryDefault<TEntity> : IRepository<TEntity, int> where TEntity : class
    {

    }
}
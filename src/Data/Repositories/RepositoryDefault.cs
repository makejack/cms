using www.veinid365.cn.Data.IRepositories;

namespace www.veinid365.cn.Data.Repositories
{
    public class RepositoryDefault<TEntity> : Repository<TEntity, int>, IRepositoryDefault<TEntity> where TEntity : class
    {
        public RepositoryDefault(AppDatabase context) : base(context)
        {
        }
    }
}
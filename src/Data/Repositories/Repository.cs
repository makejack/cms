using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using www.veinid365.cn.Data.IRepositories;

namespace www.veinid365.cn.Data.Repositories
{
    public class Repository<TEntity, TKey> : Repository<TEntity>, IRepository<TEntity, TKey> where TEntity : class
    {
        public Repository(AppDatabase context) : base(context)
        {
        }


        public Task<TEntity> FirstOrDefaultAsync(TKey key)
        {
            return DbSet.FirstOrDefaultAsync(CreateEqualityExpressionForId(key));
        }

        /// <summary>
        /// 根据主键构建判断表达式
        /// </summary>
        /// <param name="key">主键</param>
        /// <returns></returns>
        protected Expression<Func<TEntity, bool>> CreateEqualityExpressionForId(TKey key)
        {
            var lambdaParam = Expression.Parameter(typeof(TEntity));
            var lambdaBody = Expression.Equal(
                Expression.PropertyOrField(lambdaParam, "Id"),
                Expression.Constant(key, typeof(TKey))
                );

            return Expression.Lambda<Func<TEntity, bool>>(lambdaBody, lambdaParam);
        }
    }

    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        public Repository(AppDatabase context)
        {
            this.Context = context;
            this.DbSet = context.Set<TEntity>();
        }

        public DbContext Context { get; set; }

        public DbSet<TEntity> DbSet { get; set; }

        public IQueryable<TEntity> Query()
        {
            return DbSet.AsQueryable();
        }

        public int Insert(TEntity entity, bool isSave = true)
        {
            DbSet.Add(entity);
            if (!isSave) return 0;
            return Save();
        }

        public Task<int> InsertAsync(TEntity entity, bool isSave = true)
        {
            DbSet.AddAsync(entity);
            if (!isSave) Task.FromResult(0);
            return SaveAsync();
        }

        public int Update(TEntity entity, bool isSave = true)
        {
            DbSet.Update(entity);
            if (!isSave) return 0;
            return Save();
        }

        public Task<int> UpdateAsync(TEntity entity)
        {
            DbSet.Update(entity);
            return SaveAsync();
        }

        public int UpdatePropery(TEntity entity, params string[] propertys)
        {
            var entityEntry = DbSet.Attach(entity);
            foreach (var property in propertys)
            {
                entityEntry.Property(property).IsModified = true;
            }
            return Save();
        }

        public Task<int> UpdateProperyAsync(TEntity entity, params string[] propertys)
        {
            var entityEntry = DbSet.Attach(entity);
            foreach (var property in propertys)
            {
                entityEntry.Property(property).IsModified = true;
            }
            return SaveAsync();
        }

        public int Remove(TEntity entity, bool isSave = true)
        {
            DbSet.Remove(entity);
            if (!isSave) return 0;
            return Save();
        }

        public Task<int> RemoveAsync(TEntity entity)
        {
            DbSet.Remove(entity);
            return SaveAsync();
        }

        public IDbContextTransaction BeginTransaction()
        {
            return Context.Database.BeginTransaction();
        }

        public int Save()
        {
            return Context.SaveChanges();
        }

        public Task<int> SaveAsync()
        {
            return Context.SaveChangesAsync();
        }
    }
}
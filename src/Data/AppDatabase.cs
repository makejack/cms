using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using www.veinid365.cn.Data.Entities;

namespace www.veinid365.cn.Data
{
    public class AppDatabase : DbContext
    {
        public AppDatabase(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDatabase).Assembly);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            BeforeSaveChanges();

            return base.SaveChangesAsync(cancellationToken);
        }

        public override int SaveChanges()
        {
            BeforeSaveChanges();

            return SaveChanges();
        }

        protected void BeforeSaveChanges()
        {
            var addEntities = this.ChangeTracker.Entries().Where(e => e.State == EntityState.Added).Select(e => e.Entity).ToList();
            foreach (var item in addEntities)
            {
                if (item is Aggregate aggregate)
                {
                    aggregate.CreateTime = DateTime.Now;
                }
            }
        }
    }
}
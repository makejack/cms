using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using www.veinid365.cn.Data.Entities;

namespace src.Data.Configurations
{
    public class NavMenuConfiguraiton : IEntityTypeConfiguration<NavMenu>
    {
        public void Configure(EntityTypeBuilder<NavMenu> builder)
        {
            builder.HasMany(e => e.Children).WithOne(e => e.Parent).HasForeignKey(e => e.ParentId);
        }
    }
}
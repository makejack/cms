using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using www.veinid365.cn.Data.Entities;

namespace www.veinid365.cn.Data.Configurations
{
    public class PageContentConfiguration : IEntityTypeConfiguration<PageContent>
    {
        public void Configure(EntityTypeBuilder<PageContent> builder)
        {
            builder.Property(e => e.Content).HasColumnType("text");
        }
    }
}
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using www.veinid365.cn.Data.Entities;

namespace www.veinid365.cn.Data.Configurations
{
    public class WebsiteCustomParamConfiguration : IEntityTypeConfiguration<WebsiteCustomParam>
    {
        public void Configure(EntityTypeBuilder<WebsiteCustomParam> builder)
        {
            builder.Property(e => e.Value).HasColumnType("text");
        }
    }
}
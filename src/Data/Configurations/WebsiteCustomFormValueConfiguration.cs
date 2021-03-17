using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using www.veinid365.cn.Data.Entities;

namespace www.veinid365.cn.Data.Configurations
{
    public class WebsiteCustomFormValueConfiguration : IEntityTypeConfiguration<WebsiteCustomFormValue>
    {
        public void Configure(EntityTypeBuilder<WebsiteCustomFormValue> builder)
        {
            builder.Property(e => e.Value).HasColumnType("text");
        }
    }
}
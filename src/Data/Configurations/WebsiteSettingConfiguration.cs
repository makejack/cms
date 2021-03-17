using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using www.veinid365.cn.Data.Entities;

namespace www.veinid365.cn.Data.Configurations
{
    public class WebsiteSettingConfiguration : IEntityTypeConfiguration<WebsiteSetting>
    {
        public void Configure(EntityTypeBuilder<WebsiteSetting> builder)
        {
            
        }
    }
}
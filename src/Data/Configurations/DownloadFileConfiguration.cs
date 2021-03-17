using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using www.veinid365.cn.Data.Entities;

namespace www.veinid365.cn.Data.Configurations
{
    public class DownloadFileConfiguration : IEntityTypeConfiguration<DownloadFile>
    {
        public void Configure(EntityTypeBuilder<DownloadFile> builder)
        {
            builder.HasOne(e => e.PageContent).WithMany(e => e.DownloadFiles).HasForeignKey(e => e.PageContentId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
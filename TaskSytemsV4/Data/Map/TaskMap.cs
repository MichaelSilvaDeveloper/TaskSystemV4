using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskSytemsV4.Models;

namespace TaskSytemsV4.Data.Map
{
    public class TaskMap : IEntityTypeConfiguration<TaskModel>
    {
        public void Configure(EntityTypeBuilder<TaskModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Descripition).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Status).IsRequired();
            builder.Property(x => x.UserId);

            builder.HasOne(x => x.User);
        }
    }
}
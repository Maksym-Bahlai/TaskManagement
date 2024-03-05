using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using TaskManagement.Domain.ToDoTasks;

namespace TaskManagement.Infrastructure.Tasks.Persistence;

public class TaskConfigurations : IEntityTypeConfiguration<ToDoTask>
{
    public void Configure(EntityTypeBuilder<ToDoTask> builder)
    {
        builder.HasKey(t => t.Id);

        builder.Property(t => t.Id)
            .ValueGeneratedNever();

        builder.Property(t => t.Description).IsRequired();

        builder.Property(t => t.State).IsRequired();

        builder.Property(t => t.ReassignCount).IsRequired();

        builder.Property(t => t.State).HasConversion(
            v => v.Name,
            v => TaskState.FromName(v, false));
    }
}
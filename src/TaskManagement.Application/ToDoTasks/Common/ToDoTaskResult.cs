using TaskManagement.Domain.ToDoTasks;

namespace TaskManagement.Application.ToDoTasks.Common;

public record ToDoTaskResult(Guid Id, string Description, TaskState State);
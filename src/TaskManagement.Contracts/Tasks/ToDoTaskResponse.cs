using TaskManagement.Contracts.Common;

namespace TaskManagement.Contracts.Tasks;

public record ToDoTaskResponse(Guid Id, string Description, TaskStateResult State);

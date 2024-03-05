using Ardalis.SmartEnum;

namespace TaskManagement.Domain.ToDoTasks;

public class TaskState(string name, int value)
    : SmartEnum<TaskState>(name, value)
{
    public static readonly TaskState Waiting = new(nameof(Waiting), 0);
    public static readonly TaskState InProgress = new(nameof(InProgress), 1);
    public static readonly TaskState Completed = new(nameof(Completed), 2);
}
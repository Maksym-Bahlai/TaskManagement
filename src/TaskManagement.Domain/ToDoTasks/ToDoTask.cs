using TaskManagement.Domain.Common;
using TaskManagement.Domain.Users;

namespace TaskManagement.Domain.ToDoTasks;

public class ToDoTask : Entity
{
    public Guid? UserId { get; private set; }
    public string Description { get; }
    public int ReassignCount { get; private set; } = 0;
    public TaskState State { get; private set; }
    public User? User { get; }

    public ToDoTask(Guid id, string description, TaskState state, Guid? userId = null)
        : base(id)
    {
        UserId = userId;
        Description = description;
        State = state;
        ReassignCount = 0;
    }

    public void AssignUser(Guid userId)
    {
        UserId = userId;
        State = TaskState.InProgress;
    }

    public void ReassignUser(Guid userId)
    {
        if (ReassignCount >= 3)
        {
            UserId = null;
            State = TaskState.Completed;
        }
        else
        {
            UserId = userId;
            State = TaskState.InProgress;
            ReassignCount += 1;
        }
    }

    public void UnassignedUser()
    {
        UserId = null;
        State = TaskState.Waiting;
    }

    private ToDoTask(string description, TaskState state)
    {
        Description = description;
        State = state;
    }
}
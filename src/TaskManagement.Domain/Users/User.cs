using ErrorOr;
using TaskManagement.Domain.Common;
using TaskManagement.Domain.ToDoTasks;
using TaskManagement.Domain.Users.Events;

namespace TaskManagement.Domain.Users;

public class User : Entity
{
    public string UserName { get; }

    public string Email { get; } = null!;

    public string FirstName { get; } = null!;

    public string LastName { get; } = null!;

    public List<ToDoTask> Tasks { get; } = new List<ToDoTask>();

    public User(
        Guid id,
        string userName,
        string firstName,
        string lastName,
        string email)
        : base(id)
    {
        UserName = userName;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
    }

    private User(string userName)
    {
        UserName = userName;
    }

    public ErrorOr<Success> AssignTask(Guid taskId)
    {
        _domainEvents.Add(new TaskAssignEvent(taskId, Id));

        return Result.Success;
    }
}
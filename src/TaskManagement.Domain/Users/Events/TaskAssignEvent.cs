using TaskManagement.Domain.Common;

namespace TaskManagement.Domain.Users.Events;

public record TaskAssignEvent(Guid TaskId, Guid UserId) : IDomainEvent;
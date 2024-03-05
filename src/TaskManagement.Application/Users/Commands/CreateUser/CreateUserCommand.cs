using ErrorOr;
using MediatR;

using TaskManagement.Application.Users.Common;

namespace TaskManagement.Application.Users.Commands.CreateUser;

public record CreateUserCommand(
    string UserName,
    string FirstName,
    string LastName,
    string Email)
    : IRequest<ErrorOr<UserResult>>;
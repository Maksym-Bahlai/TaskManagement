using ErrorOr;
using MediatR;
using TaskManagement.Application.Users.Common;

namespace TaskManagement.Application.Users.Queries;

public record GetUserQuery(string UserName) : IRequest<ErrorOr<UserResult>>;
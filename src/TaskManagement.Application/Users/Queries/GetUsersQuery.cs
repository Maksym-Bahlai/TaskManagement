using ErrorOr;
using MediatR;
using TaskManagement.Application.Users.Common;

namespace TaskManagement.Application.Users.Queries;

public record GetUsersQuery() : IRequest<ErrorOr<List<UserResult>>>;
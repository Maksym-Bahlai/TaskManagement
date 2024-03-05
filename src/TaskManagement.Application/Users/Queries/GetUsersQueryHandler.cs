using AutoMapper;
using ErrorOr;
using MediatR;
using TaskManagement.Application.Common.Interfaces;
using TaskManagement.Application.Users.Common;

using TaskManagement.Domain.Users;

namespace TaskManagement.Application.Users.Queries;

public class GetUsersQueryHandler(IUsersRepository _usersRepository, IMapper _mapper)
    : IRequestHandler<GetUsersQuery, ErrorOr<List<UserResult>>>
{
    public async Task<ErrorOr<List<UserResult>>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
        return await _usersRepository.GetAllAsync(cancellationToken) is List<User> users && users.Any()
            ? _mapper.Map<List<UserResult>>(users)
            : Error.NotFound(description: "Users not found.");
    }
}

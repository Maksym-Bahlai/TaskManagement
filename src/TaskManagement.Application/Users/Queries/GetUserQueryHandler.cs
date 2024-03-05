using AutoMapper;
using ErrorOr;
using MediatR;
using TaskManagement.Application.Common.Interfaces;
using TaskManagement.Application.Users.Common;

using TaskManagement.Domain.Users;

namespace TaskManagement.Application.Users.Queries;

public class GetUserQueryHandler(IUsersRepository _usersRepository, IMapper _mapper)
    : IRequestHandler<GetUserQuery, ErrorOr<UserResult>>
{
    public async Task<ErrorOr<UserResult>> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        return await _usersRepository.GetByUserNameAsync(request.UserName, cancellationToken) is { } user
            ? _mapper.Map<UserResult>(user)
            : Error.NotFound(description: "User not found.");
    }
}

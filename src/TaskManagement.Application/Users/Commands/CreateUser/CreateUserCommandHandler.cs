using AutoMapper;

using ErrorOr;

using MediatR;

using TaskManagement.Application.Common.Interfaces;
using TaskManagement.Application.Users.Common;

using TaskManagement.Domain.Users;

namespace TaskManagement.Application.Users.Commands.CreateUser;

public class CreateUserCommandHandler(IUsersRepository _usersRepository, IMapper _mapper) : IRequestHandler<CreateUserCommand, ErrorOr<UserResult>>
{
    public async Task<ErrorOr<UserResult>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        if (await _usersRepository.GetByUserNameAsync(request.UserName, cancellationToken) is not null)
        {
            return Error.Conflict(description: "User already exist");
        }

        var user = new User(
            Guid.NewGuid(),
            request.UserName,
            request.FirstName,
            request.LastName,
            request.Email);

        await _usersRepository.AddAsync(user, cancellationToken);

        return _mapper.Map<UserResult>(user);
    }
}
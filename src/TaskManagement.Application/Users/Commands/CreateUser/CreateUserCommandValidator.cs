using FluentValidation;

namespace TaskManagement.Application.Users.Commands.CreateUser;

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(x => x.UserName).MinimumLength(3).MaximumLength(18);
        RuleFor(x => x.FirstName).MinimumLength(3).MaximumLength(18);
        RuleFor(x => x.LastName).MinimumLength(3).MaximumLength(18);
        RuleFor(x => x.Email).EmailAddress();
    }
}
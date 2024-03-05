using FluentValidation;

namespace TaskManagement.Application.ToDoTasks.Commands.CreateTask;

public class CreateTaskCommandValidator : AbstractValidator<CreateTaskCommand>
{
    public CreateTaskCommandValidator()
    {
        RuleFor(x => x.Description).MinimumLength(5).MaximumLength(10000);
    }
}
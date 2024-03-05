using AutoMapper;

using TaskManagement.Application.ToDoTasks.Common;
using TaskManagement.Application.Users.Common;
using TaskManagement.Contracts.Common;
using TaskManagement.Contracts.Tasks;
using TaskManagement.Contracts.Users;
using TaskManagement.Domain.ToDoTasks;
using TaskManagement.Domain.Users;

namespace TaskManagement.Application.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<ToDoTask, ToDoTaskResult>();
        CreateMap<ToDoTaskResult, ToDoTaskResponse>();
        CreateMap<TaskState, TaskStateResult>();
        CreateMap<User, UserResult>();
        CreateMap<UserResult, UserResponse>();
    }
}
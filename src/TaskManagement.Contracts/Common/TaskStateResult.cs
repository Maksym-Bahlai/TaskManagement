using System.Text.Json.Serialization;

namespace TaskManagement.Contracts.Common;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum TaskStateResult
{
    Waiting,
    InProgress,
    Completed,
}
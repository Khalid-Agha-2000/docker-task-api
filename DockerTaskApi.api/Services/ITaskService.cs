using DockerTaskApi.Api.Models;

namespace DockerTaskApi.Api.Services;

public interface ITaskService
{
    Task<List<TaskItem>> GetAllTasksAsync();

    Task<TaskItem> GetTaskById(int id);

    Task<TaskItem> CreateTask(TaskItem task);
    Task<TaskItem> UpdateTask(TaskItem task);
    Task DeleteTask(int id);
}
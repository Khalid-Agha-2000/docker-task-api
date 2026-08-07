using Microsoft.EntityFrameworkCore;
using DockerTaskApi.Api.Models;
using DockerTaskApi.Api.Services;
using DockerTaskApi.Api.Data;

namespace DockerTaskApi.Api.Services;

public class TaskService : ITaskService
{
    private readonly ApplicationDbContext _context;
    public TaskService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<TaskItem>> GetAllTasksAsync()
    {
        return await _context.Tasks.ToListAsync();
    }

    public async Task<TaskItem> GetTaskById(int id)
    {
        var task = await _context.Tasks.FirstOrDefaultAsync(t => t.Id == id);
        if (task == null)
        {
            return null;
        }
        return task;
    }

    public async Task<TaskItem> CreateTask(TaskItem task)
    {
        _context.Tasks.Add(task);
        await _context.SaveChangesAsync();
        return task;
    }

    public async Task<TaskItem?> UpdateTask(TaskItem task)
    {
        var old = await _context.Tasks.FirstOrDefaultAsync(t => t.Id == task.Id);
        if(old == null)
        {
            return null;
        }
        old.Title = task.Title;
        old.Description = task.Description;
        old.IsCompleted = task.IsCompleted;
        await _context.SaveChangesAsync();
        return task;
    }

    public async Task DeleteTask(int id)
    {
        var task = await _context.Tasks.FirstOrDefaultAsync(t => t.Id == id);
        if (task == null)
        {
            return;
        }
        else _context.Tasks.Remove(task);
        await _context.SaveChangesAsync();
    }
}
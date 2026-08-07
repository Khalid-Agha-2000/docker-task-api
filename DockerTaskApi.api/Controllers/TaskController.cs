using DockerTaskApi.Api.Models;
using DockerTaskApi.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace DockerTaskApi.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TaskController : ControllerBase
{
    private readonly ITaskService _TaskService;
    public TaskController(ITaskService taskService)
    {
        _TaskService = taskService;
    }

    [HttpGet]
    [Route("get-all-tasks")]
    public async Task<ActionResult<List<TaskItem>>> GetAllTasksAsync()
    {
        return Ok(await _TaskService.GetAllTasksAsync());
    }

    [HttpGet]
    [Route("task/{id}")]
    public async Task<ActionResult<TaskItem>> GetTaskById(int id)
    {
        var task = await _TaskService.GetTaskById(id);
        if(task == null)
        {
            return NotFound();
        }
        return Ok(task);
    }

    [HttpPost]
    [Route("task/create")]
    public async Task<ActionResult<TaskItem>> CreateTask(TaskItem task)
    {
        return Ok(await _TaskService.CreateTask(task));
    }

    [HttpPatch]
    [Route("update")]
    public async Task<ActionResult<TaskItem>> UpdateTask(TaskItem task)
    {
        var updated = await _TaskService.UpdateTask(task);
        if(updated == null)
        {
            return NotFound();
        }
        return Ok(updated);
    }

    [HttpDelete]
    [Route("delete/{id}")]
    public async Task<ActionResult> DeleteTask(int id)
    {
        await _TaskService.DeleteTask(id);
        return NoContent();
    }
}
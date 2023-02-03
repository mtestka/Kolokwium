using Kolokwium.Data;
using Kolokwium.Models;
using Kolokwium.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TasksController : ControllerBase
{

    private readonly ILogger<TasksController> _logger;
    private readonly ProjectsDbContext _projectsDbContext;

    public TasksController(ILogger<TasksController> logger, ProjectsDbContext projectsDbContext)
    {
        _logger = logger;
        _projectsDbContext = projectsDbContext;
    }

    [HttpPost]
    public async Task<IActionResult> Post(TaskPostDTO task)
    {
        var taskType = task.TaskType;

        var checkIfTaskTypeExists = _projectsDbContext.TaskTypes.Any(a => a.Name == taskType.Name);

        if (!checkIfTaskTypeExists)
        {
            var newTaskType = new TaskType() { Name = taskType.Name };
            _projectsDbContext.TaskTypes.Add(newTaskType);
            _projectsDbContext.SaveChanges();
        }

        if(!_projectsDbContext.TeamMembers.Any(a=>a.IdTeamMember == task.IdAssignedTo))
        {
            return NotFound("Team member not found in db.");
        }

        if (!_projectsDbContext.TeamMembers.Any(a => a.IdTeamMember == task.IdCreator))
        {
            return NotFound("Team member not found in db.");
        }

        if (!_projectsDbContext.Projects.Any(a => a.IdTeam == task.IdTeam))
        {
            return NotFound("Project not found in db.");
        }

        var getTaskType = _projectsDbContext.TaskTypes.FirstOrDefault(a => a.Name == taskType.Name);

        var newTask = new Models.Task();

        newTask.Name = task.Name;
        newTask.Description = task.Description;
        newTask.Deadline = task.Deadline;
        newTask.IdTeam = task.IdTeam;
        newTask.IdAssignedTo = task.IdAssignedTo;
        newTask.IdCreator = task.IdCreator;
        newTask.IdTaskType = getTaskType.IdTaskType;

        _projectsDbContext.Tasks.Add(newTask);

        _projectsDbContext.SaveChanges();

        return Ok();
    }
}


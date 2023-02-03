using Kolokwium.Data;
using Kolokwium.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProjectsController : ControllerBase
{

    private readonly ILogger<ProjectsController> _logger;
    private readonly ProjectsDbContext _projectsDbContext;

    public ProjectsController(ILogger<ProjectsController> logger, ProjectsDbContext projectsDbContext)
    {
        _logger = logger;
        _projectsDbContext = projectsDbContext;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var project = await _projectsDbContext.Projects.Include(a => a.Tasks).ThenInclude(a => a.TaskType).FirstOrDefaultAsync();

        if (project == null)
            return NotFound();

        return Ok(new ProjectDTO(project));
    }
}


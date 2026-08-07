using Microsoft.EntityFrameworkCore;
using DockerTaskApi.Api.Models;

namespace DockerTaskApi.Api.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<TaskItem> Tasks{get; set;}
}
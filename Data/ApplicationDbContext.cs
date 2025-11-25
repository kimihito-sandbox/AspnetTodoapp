using Microsoft.EntityFrameworkCore;
using AspnetTodoapp.Models;

namespace AspnetTodoapp.Data;

public class ApplicationDbContext : DbContext
{
  public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
  {}

  public DbSet<Todo> Todos => Set<Todo>();
}

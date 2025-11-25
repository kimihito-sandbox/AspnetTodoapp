using AspnetTodoapp.Models;

namespace AspnetTodoapp.Data;

public static class DbInitializer
{
  public static void Seed(ApplicationDbContext context)
  {
    if (context.Todos.Any())
    {
      Console.WriteLine("==> シードデータはすでに存在するためスキップします");
      return; // DB has been seeded
    }

    context.Todos.AddRange(
      new Todo { Title = "Learn HTMX", IsCompleted = true },
      new Todo { Title = "Build an ASP.NET Core app", IsCompleted = false },
      new Todo { Title = "Profit!", IsCompleted = false }
    );

    context.SaveChanges();
    Console.WriteLine("==> シードデータを追加しました");
  }

}

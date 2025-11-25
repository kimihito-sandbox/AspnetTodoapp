using Microsoft.AspNetCore.Mvc;
using Htmx;
using AspnetTodoapp.Models;
using AspnetTodoapp.Data;

namespace AspnetTodoapp.Controllers;

public class TodoController : Controller
{
    private readonly ApplicationDbContext _context;
    public TodoController(ApplicationDbContext context)
    {
        _context = context;
    }

    [Route("/todos")]
    [HttpGet]
    public IActionResult Index()
    {
        var todos = _context.Todos.ToList();

        if (Request.IsHtmx())
        {
            return PartialView(todos);
        }
        return View(todos);
    }

    [Route("/todos/new")]
    [HttpGet]
    public IActionResult New()
    {
      return View();
    }

    [Route("/todos")]
    [HttpPost]
    public IActionResult Create(CreateTodoRequest request)
    {

      if (!ModelState.IsValid)
      {
        return View(nameof(New), request);
      }

      var todo = new Todo
      {
        Title = request.Title,
        IsCompleted = false
      };

      _context.Todos.Add(todo);
      _context.SaveChanges();

      return RedirectToAction(nameof(Index));

    }
}

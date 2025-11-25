using Microsoft.AspNetCore.Mvc;
using Htmx;
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
}

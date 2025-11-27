using Microsoft.AspNetCore.Mvc;
using AspnetTodoapp.Models;
using Microsoft.AspNetCore.Html;

namespace AspnetTodoapp.ViewComponents;

public class TodoItemViewComponent : ViewComponent
{
    public IViewComponentResult Invoke(Todo item, IHtmlContent? completed = null, IHtmlContent? pending = null)
    {
        return View(item);
    }
}

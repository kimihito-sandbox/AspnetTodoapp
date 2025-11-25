using FluentValidation;
using AspnetTodoapp.Models;

namespace AspnetTodoapp.Validators;

public class CreateTodoRequestValidator: AbstractValidator<CreateTodoRequest>
{
  public CreateTodoRequestValidator()
  {
    RuleFor(x => x.Title)
      .NotEmpty().WithMessage("タイトルを入力してください")
      .MaximumLength(100).WithMessage("タイトルは100文字以内で入力してください");
  }
}

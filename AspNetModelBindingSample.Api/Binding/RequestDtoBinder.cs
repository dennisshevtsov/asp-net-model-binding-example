// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace AspNetModelBindingSample.Api.Binding
{
  using AspNetModelBindingSample.Api.Dtos;
  using Microsoft.AspNetCore.Mvc.ModelBinding;

  public sealed class RequestDtoBinder : IModelBinder
  {
    private readonly IModelBinder _bodyModelBinder;

    public RequestDtoBinder(IModelBinder bodyModelBinder)
    {
      _bodyModelBinder = bodyModelBinder;
    }

    public Task BindModelAsync(ModelBindingContext bindingContext)
    {
      _bodyModelBinder.BindModelAsync(bindingContext);

      var todoListIdValue = bindingContext.ValueProvider.GetValue(nameof(AddTodoListTaskRequestDto.TodoListId));

      if (!string.IsNullOrWhiteSpace(todoListIdValue.FirstValue) &&
          Guid.TryParse(todoListIdValue.FirstValue, out var todoListId))
      {
        var property = bindingContext.ModelType.GetProperty(nameof(AddTodoListTaskRequestDto.TodoListId));

        if (property != null)
        {
          property.SetValue(bindingContext.Result.Model, todoListId);
        }
      }

      return Task.CompletedTask;
    }
  }
}

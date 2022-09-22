// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace AspNetModelBindingSample.Api.Binding
{
  using Microsoft.AspNetCore.Mvc.ModelBinding;

  using AspNetModelBindingSample.Api.Dtos;

  public sealed class RequestDtoBinderProvider : IModelBinderProvider
  {
    public IModelBinder? GetBinder(ModelBinderProviderContext context)
    {
      if (context.Metadata.ModelType == typeof(AddTodoListTaskRequestDto))
      {
        return new RequestDtoBinder();
      }

      return null;
    }
  }
}

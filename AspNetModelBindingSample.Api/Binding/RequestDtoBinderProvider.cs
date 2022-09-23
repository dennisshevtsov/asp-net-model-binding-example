// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace AspNetModelBindingSample.Api.Binding
{
  using System;

  using Microsoft.AspNetCore.Mvc;
  using Microsoft.AspNetCore.Mvc.ModelBinding;
  using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;

  using AspNetModelBindingSample.Api.Dtos;

  public sealed class RequestDtoBinderProvider : IModelBinderProvider
  {
    private readonly MvcOptions _mvcOptions;

    public RequestDtoBinderProvider(MvcOptions mvcOptions)
    {
      _mvcOptions = mvcOptions ?? throw new ArgumentNullException(nameof(mvcOptions));
    }

    public IModelBinder? GetBinder(ModelBinderProviderContext context)
    {
      if (context.Metadata.ModelType != typeof(AddTodoListTaskRequestDto))
      {
        return null;
      }

      var bodyModelBinderProvider =
        _mvcOptions.ModelBinderProviders.FirstOrDefault(
          provider => provider is BodyModelBinderProvider);

      if (bodyModelBinderProvider == null)
      {
        return null;
      }

      context.BindingInfo.BindingSource = BindingSource.Body;

      var bodyModelBinder = bodyModelBinderProvider.GetBinder(context);

      if (bodyModelBinder == null)
      {
        return null;
      }

      return new RequestDtoBinder(bodyModelBinder);
    }
  }
}

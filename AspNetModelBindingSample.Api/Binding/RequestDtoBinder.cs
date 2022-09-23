// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace AspNetModelBindingSample.Api.Binding
{
  using System.ComponentModel;

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

      if (bindingContext.Result.Model == null)
      {
        return Task.CompletedTask;
      }

      foreach (var property in bindingContext.ModelMetadata.Properties)
      {
        if (bindingContext.ActionContext.RouteData.Values.TryGetValue(property.Name, out var routeValue) &&
            routeValue != null)
        {
          var converter = TypeDescriptor.GetConverter(property.ModelType);

          if (converter != null && property.PropertySetter != null)
          {
            var value = converter.ConvertFrom(routeValue);

            property.PropertySetter(bindingContext.Result.Model, value);
          }
        }
      }

      return Task.CompletedTask;
    }
  }
}

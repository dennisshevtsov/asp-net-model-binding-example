// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace AspNetModelBindingSample.Api.Binding
{
  using Microsoft.AspNetCore.Mvc.ModelBinding;

  public sealed class RequestDtoBinder : IModelBinder
  {
    public Task BindModelAsync(ModelBindingContext bindingContext)
    {
      throw new NotImplementedException();
    }
  }
}

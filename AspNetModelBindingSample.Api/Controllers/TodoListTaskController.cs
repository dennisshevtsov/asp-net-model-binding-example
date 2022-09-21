// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace AspNetModelBindingSample.Api.Controllers
{
  using Microsoft.AspNetCore.Mvc;

  [Route("api/todo-list/{todoListId}")]
  [Produces("application/json")]
  public sealed class TodoListTaskController : ControllerBase
  {
  }
}

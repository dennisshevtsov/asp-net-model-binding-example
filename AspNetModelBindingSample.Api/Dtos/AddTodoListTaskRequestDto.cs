﻿// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace AspNetModelBindingSample.Api.Dtos
{
  public sealed class AddTodoListTaskRequestDto
  {
    public Guid TodoListId { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }
  }
}

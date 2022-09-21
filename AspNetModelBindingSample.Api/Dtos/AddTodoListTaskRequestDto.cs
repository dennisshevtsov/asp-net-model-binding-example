namespace AspNetModelBindingSample.Api.Dtos
{
  public sealed class AddTodoListTaskRequestDto
  {
    public Guid TodoListId { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }
  }
}

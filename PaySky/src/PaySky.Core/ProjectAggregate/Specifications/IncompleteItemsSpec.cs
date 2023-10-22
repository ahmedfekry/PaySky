using Ardalis.Specification;

namespace PaySky.Core.ProjectAggregate.Specifications;
public class IncompleteItemsSpec : Specification<ToDoItem>
{
  public IncompleteItemsSpec()
  {
    Query.Where(item => !item.IsDone);
  }
}

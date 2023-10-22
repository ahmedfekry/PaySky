using Ardalis.Result;
using PaySky.Core.ProjectAggregate;

namespace PaySky.Core.Interfaces;
public interface IToDoItemSearchService
{
  Task<Result<ToDoItem>> GetNextIncompleteItemAsync(int projectId);
  Task<Result<List<ToDoItem>>> GetAllIncompleteItemsAsync(int projectId, string searchString);
}

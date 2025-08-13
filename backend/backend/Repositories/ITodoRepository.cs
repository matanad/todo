using backend.Models;

namespace backend.Repositories
{
    public interface ITodoRepository
    {
        Task<int> AddTodoAsync(Todo todo);
        Task<List<Todo>> GetAllTodosAsync();
        Task<List<Todo>> GetTodoByCategoryAsync(string category);
    }
}
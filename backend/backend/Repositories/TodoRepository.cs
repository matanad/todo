using backend.Data;
using backend.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly TodoContext _context;
        public TodoRepository(TodoContext context)
        {
            _context = context;
        }

        public async Task<List<Todo>> GetAllTodosAsync()
        {
            try
            {
                return await _context.Todos.ToListAsync();
            }
            catch
            {
                return new List<Todo>();
            }
        }

        public async Task<List<Todo>> GetTodoByCategoryAsync(string category)
        {
            try
            {
                return await _context.Todos
                    .Where(t => t.Category == category)
                    .ToListAsync();
            }
            catch
            {
                return new List<Todo>();
            }
        }

        public async Task<int> AddTodoAsync(Todo todo)
        {
            try
            {
                _context.Todos.Add(todo);
                return await _context.SaveChangesAsync();
            }
            catch
            {
                return 0;
            }
        }
    }
}

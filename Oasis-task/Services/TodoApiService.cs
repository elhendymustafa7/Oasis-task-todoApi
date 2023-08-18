using Microsoft.AspNetCore.Identity;
using Oasis_task.Authentication;
using Oasis_task.Model;
using System;

namespace Oasis_task.Services
{
    public class TodoApiService
    {
        private readonly HttpClient _httpClient;
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<User> userManager;

        public TodoApiService(HttpClient httpClient, ApplicationDbContext dbContext, UserManager<User> userManager)
        {
            _httpClient = httpClient;
            _dbContext = dbContext;
            this.userManager = userManager;
        }

        public async Task ImportTodosFromApiAsync()
        {
            var response = await _httpClient.GetAsync("https://jsonplaceholder.typicode.com/todos");
            if (response.IsSuccessStatusCode)
            {
                var todos = await response.Content.ReadFromJsonAsync<List<Todo>>();
                    int i = 0;
                foreach (var todo in todos)
                {
                    var userExists = await userManager.FindByIdAsync(todo.UserId.ToString());

                    if (userExists == null)
                    {
                        User user = new User()
                        {
                            Email = $"email{i}@fake.com",
                            SecurityStamp = Guid.NewGuid().ToString(),
                            UserName = $"email{i}",
                            Id = todo.UserId
                        };

                        var result = await userManager.CreateAsync(user,"Mu@012aaa88");
                    };
                    

                    //Check if the todo with the same ID exists, if not, add it.
                    if (!_dbContext.Todo.Any(t => t.Id == todo.Id))
                    {
                        _dbContext.Todo.Add(todo);
                    }
                    i++;
                }
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}

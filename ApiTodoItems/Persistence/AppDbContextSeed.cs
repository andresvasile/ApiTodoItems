using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiTodoItems.Domain.Entities;

namespace ApiTodoItems.Persistence
{
    public class AppDbContextSeed
    {
        internal static async Task SeedAsync(AplicationDbContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                if (!context.TodoItems.Any())
                {
                    var todoItems = new List<TodoItem>();

                    var todoItem = new TodoItem
                    {
                        Description = "Buy groceries",
                        IsCompleted = true
                    };
                    var todoItem2 = new TodoItem
                    {
                        Description = "Prepare weekly report",
                        IsCompleted = false
                    };
                    var todoItem3 = new TodoItem
                    {
                        Description = "Write to candidates",
                        IsCompleted = true
                    };

                    todoItems.Add(todoItem);
                    todoItems.Add(todoItem2);
                    todoItems.Add(todoItem3);

                    foreach (var item in todoItems)
                    {
                        context.TodoItems.Add(item);
                    }

                    await context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                var logger = loggerFactory.CreateLogger<AplicationDbContext>();
                logger.LogError(e.Message);
            }
        }
    }
}
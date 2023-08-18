using Microsoft.EntityFrameworkCore;
using Oasis_task.Data.Repositories;
using Oasis_task.Model;
using System;

namespace Oasis_task.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;
        public ITodoRepository TodoRepository { get; private set; }
        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            TodoRepository = new TodoRepository(dbContext);
        }
      


        public async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}

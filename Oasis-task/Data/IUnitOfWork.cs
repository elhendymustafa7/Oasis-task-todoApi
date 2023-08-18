using Oasis_task.Data.Repositories;

namespace Oasis_task.Data
{
    public interface IUnitOfWork
    {
        ITodoRepository TodoRepository { get; }
        Task<int> SaveChangesAsync();
    }
}

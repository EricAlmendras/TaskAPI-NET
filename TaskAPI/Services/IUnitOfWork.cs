using TaskAPI.Repository;

namespace TaskAPI.Services
{
    public interface IUnitOfWork
    {
        public TaskRepository TaskRepository { get; set; }

        public Task<int> Complete();
    }
}

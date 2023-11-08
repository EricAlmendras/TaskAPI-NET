using Microsoft.EntityFrameworkCore;
using TaskAPI.Data;
using TaskAPI.DTO_s;
using TaskAPI.Entities;

namespace TaskAPI.Repository
{
    public class TaskRepository : Repository<TaskModel>
    {
        public TaskRepository(ContextDB contextDB) : base(contextDB) { }

        public async Task<List<TaskModel>> GetAllTasks()
        {
            try
            {
                return await _contextDB.Tasks.ToListAsync();
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public async Task<TaskModel?> GetTaskId(int id)
        {
            try
            {
                return await _contextDB.Tasks.Where(x => x.Id == id).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public async Task<bool> InsertTask(TaskRegisterDTO taskRegisterDTO)
        {
            try
            {
                var task = new TaskModel();
                task = taskRegisterDTO;

                return await base.Insert(task);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> UpdateTask (TaskRegisterDTO taskRegisterDTO, int id)
        {
            try
            {
                var task = new TaskModel();
                task = taskRegisterDTO;
                task.Id = id;
                task.IsCompleted = taskRegisterDTO.IsCompleted;

                return await base.Update(task);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> DeleteTask(int id)
        {
            try
            {
                return await Delete(id);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}

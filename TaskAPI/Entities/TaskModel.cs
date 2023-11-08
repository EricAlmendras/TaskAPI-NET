using TaskAPI.DTO_s;

namespace TaskAPI.Entities
{
    public class TaskModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public bool IsCompleted { get; set; }

        public static implicit operator TaskModel (TaskRegisterDTO taskRegisterDTO)
        {
            var task = new TaskModel();
            task.Title = taskRegisterDTO.Title;
            task.Description = taskRegisterDTO.Description;
            task.IsCompleted = taskRegisterDTO.IsCompleted;

            return task;
        }

    }
}

namespace TaskAPI.DTO_s
{
    public class TaskRegisterDTO
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public bool IsCompleted { get; set; }
    }
}

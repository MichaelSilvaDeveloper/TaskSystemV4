using TaskSytemsV4.Enums;

namespace TaskSytemsV4.Models
{
    public class TaskModel
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Descripition { get; set; }

        public StatusTask Status { get; set; }

        public int UserId { get; set; }

        public UserModel? User { get; set; }
    }
}
using TaskSytemsV4.Models;

namespace TaskSytemsV4.Repositories.Interfaces
{
    public interface ITaskRepository
    {
        Task<List<TaskModel>> GetAllTasks();

        Task<TaskModel> GetTaskById(int id);

        Task<TaskModel> InsertTask(TaskModel task);
        
        Task<TaskModel> UpdateTask(TaskModel task, int id);

        Task DeleteTask(int id);
    }
}
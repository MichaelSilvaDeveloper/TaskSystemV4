using Microsoft.EntityFrameworkCore;
using TaskSytemsV4.Data;
using TaskSytemsV4.Models;
using TaskSytemsV4.Repositories.Interfaces;

namespace TaskSytemsV4.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TaskSystemDBContext _dBContext;

        public TaskRepository(TaskSystemDBContext dBContext)
        {
            _dBContext = dBContext;
        }

        public async Task<List<TaskModel>> GetAllTasks()
        {
            return await _dBContext.Tasks
                .Include(x => x.User)
                .ToListAsync();    
        }

        public async Task<TaskModel> GetTaskById(int id)
        {
            var getTaskById = await _dBContext.Tasks
                .Include(x => x.User)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (getTaskById == null)
                throw new Exception($"Usuário para o id: {id} não foi encontrado");
            return getTaskById;      
        }

        public async Task<TaskModel> InsertTask(TaskModel task)
        {
            await _dBContext.Tasks.AddAsync(task);
            await _dBContext.SaveChangesAsync();
            return task; 
        }

        public async Task<TaskModel> UpdateTask(TaskModel task, int id)
        {
            var editTaskById = await GetTaskById(id);
            if (editTaskById == null)
                throw new Exception($"Usuário para o id: {id} não foi encontrado");

            editTaskById.Name = task.Name;
            editTaskById.Descripition = task.Descripition;
            editTaskById.Status = task.Status;

            _dBContext.Tasks.Update(editTaskById);
            await _dBContext.SaveChangesAsync();
            return editTaskById;
        }

        public async Task DeleteTask(int id)
        {
            var delteTaskById = await GetTaskById(id);
            if (delteTaskById == null)
                throw new Exception($"Usuário para o id: {id} não foi encontrado");

            _dBContext.Tasks.Remove(delteTaskById);
            await _dBContext.SaveChangesAsync();
        }
    }
}
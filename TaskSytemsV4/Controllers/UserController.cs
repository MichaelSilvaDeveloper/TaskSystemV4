using Microsoft.AspNetCore.Mvc;
using TaskSytemsV4.Models;
using TaskSytemsV4.Repositories.Interfaces;

namespace TaskSytemsV4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskRepository _taskRepository;

        public TaskController(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<TaskModel>>> ExibirTodosAsTasks()
        {
            return await _taskRepository.GetAllTasks();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TaskModel>> BuscarTaskPorId(int id)
        {
            return await _taskRepository.GetTaskById(id);
        }

        [HttpPost]
        public async Task<ActionResult<TaskModel>> InsertTask([FromBody] TaskModel task)
        {
            return await _taskRepository.InsertTask(task);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TaskModel>> UpdateTask([FromBody] TaskModel task, int id)
        {
            return await _taskRepository.UpdateTask(task, id);
        }

        [HttpDelete("{id}")]
        public async Task DeleteTask(int id)
        {
            await _taskRepository.DeleteTask(id);
        }
    }
}
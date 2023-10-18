using Microsoft.AspNetCore.Mvc;
using TaskSytemsV4.Models;
using TaskSytemsV4.Repositories.Interfaces;

namespace TaskSytemsV4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserModel>>> ExibirTodosOsUsuarios()
        {
            return await _userRepository.GetAllUsers();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserModel>> BuscarUsuarioPorId(int id)
        {
            return await _userRepository.GetUserById(id);
        }

        [HttpPost]
        public async Task<ActionResult<UserModel>> InsertUser([FromBody] UserModel user)
        {
            return await _userRepository.InsertUser(user);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UserModel>> UpdateUser([FromBody] UserModel user, int id)
        {
            return await _userRepository.UpdateUser(user, id);
        }

        [HttpDelete("{id}")]
        public async Task DeleteUser(int id)
        {
            await _userRepository.DeleteUser(id);
        }
    }
}
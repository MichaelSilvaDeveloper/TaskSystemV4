using Microsoft.EntityFrameworkCore;
using TaskSytemsV4.Data;
using TaskSytemsV4.Models;
using TaskSytemsV4.Repositories.Interfaces;

namespace TaskSytemsV4.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly TaskSystemDBContext _dBContext;

        public UserRepository(TaskSystemDBContext dBContext)
        {
            _dBContext = dBContext;
        }

        public async Task<List<UserModel>> GetAllUsers()
        {
            return await _dBContext.Users.ToListAsync();    
        }

        public async Task<UserModel> GetUserById(int id)
        {
            var getUserById = await _dBContext.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (getUserById == null)
                throw new Exception($"Usuário para o id: {id} não foi encontrado");
            return getUserById;      
        }

        public async Task<UserModel> InsertUser(UserModel user)
        {
            await _dBContext.Users.AddAsync(user);
            await _dBContext.SaveChangesAsync();
            return user; 
        }

        public async Task<UserModel> UpdateUser(UserModel user, int id)
        {
            var editUserById = await GetUserById(id);
            if (editUserById == null)
                throw new Exception($"Usuário para o id: {id} não foi encontrado");

            editUserById.Name = user.Name;
            editUserById.Email = user.Email;

            _dBContext.Users.Update(editUserById);
            await _dBContext.SaveChangesAsync();
            return editUserById;
        }

        public async Task DeleteUser(int id)
        {
            var editUserById = await GetUserById(id);
            if (editUserById == null)   
                throw new Exception($"Usuário para o id: {id} não foi encontrado");

            _dBContext.Users.Remove(editUserById);
            await _dBContext.SaveChangesAsync();
        }
    }
}
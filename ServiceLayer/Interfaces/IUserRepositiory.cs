using DataAccessLibrary.Models;
using EdominarAssignmentTask.Models;

namespace ServiceLayer.Interfaces
{
    public interface IUserRepositiory
    {

        Task<IEnumerable<UserInfo>> GetUsers();
        Task<UserInfo> GetUserById(int Id);
        Task AddUser(User user);
        Task UpdateUser(User user);
        Task DeleteUser(int Id);
        Task<IEnumerable<State>> GetStates();
        Task<IEnumerable<Hobby>> GetHobbies();



    }
}

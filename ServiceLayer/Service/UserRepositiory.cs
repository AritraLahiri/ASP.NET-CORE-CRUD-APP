using DataAccessLibrary;
using DataAccessLibrary.Models;
using EdominarAssignmentTask.Models;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.Interfaces;
using System.Diagnostics;

namespace ServiceLayer.Service
{
    public class UserRepositiory : IUserRepositiory
    {

        private readonly AppDbContext _dbContext;

        public UserRepositiory(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<IEnumerable<State>> GetStates()
        {
            var states = new List<State>();
            try
            {
                states = await _dbContext.State.ToListAsync<State>();
            }
            catch (Exception e)
            {

                states.Add(new State()
                {
                    Id = 0,
                    Name = e.Message
                });

            }

            return states;
        }
        public async Task<IEnumerable<Hobby>> GetHobbies()
        {
            var hobby = new List<Hobby>();
            try
            {
                hobby = await _dbContext.Hobbies.ToListAsync<Hobby>();
            }
            catch (Exception e)
            {

                hobby.Add(new Hobby()
                {
                    Id = 0,
                    Name = e.Message
                });

            }

            return hobby;
        }
        public async Task<IEnumerable<UserInfo>> GetUsers()

        {
            var users = new List<User>();
            List<UserInfo> data = new();

            try
            {
                users = await _dbContext.User.ToListAsync<User>();
                foreach (var user in users)
                {
                    var hobbyList = await _dbContext.Hobbies.Where(x => x.Id == user.HobbyId).FirstOrDefaultAsync();
                    var stateList = await _dbContext.State.Where(x => x.Id == user.StateId).FirstOrDefaultAsync();
                    data.Add(new UserInfo()
                    {
                        Id = user.Id,
                        Name = user.Name,
                        Email = user.Email,
                        Address = user.Address,
                        Mobile = user.Mobile,
                        Hobby = hobbyList.Name ?? "Empty",
                        State = stateList.Name ?? "Empty",
                        Gender = user.Gender
                    });


                }
                return data;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            return data;
        }
        public async Task AddUser(User user)
        {
            try
            {
                await _dbContext.AddAsync(user);
                _dbContext.SaveChanges();
            }
            catch (Exception e)
            {

                Debug.WriteLine(e.Message);
            }
        }

        public async Task<UserInfo> GetUserById(int Id)
        {
            User? user = new User();
            UserInfo data = new();

            try
            {
                user = await _dbContext.User.Where(x => x.Id == Id).FirstOrDefaultAsync();
                if (user != null)
                {
                    var hobby = await _dbContext.Hobbies.Where(x => x.Id == user.HobbyId).FirstOrDefaultAsync();
                    var state = await _dbContext.State.Where(x => x.Id == user.StateId).FirstOrDefaultAsync();
                    data = new UserInfo()
                    {
                        Id = user.Id,
                        Name = user.Name,
                        Email = user.Email,
                        Address = user.Address,
                        Mobile = user.Mobile,
                        HobbyId = user.HobbyId,
                        StateId = user.StateId,
                        Hobby = hobby.Name ?? "Empty",
                        State = state.Name ?? "Empty",
                        Gender = user.Gender
                    };

                }
                return data;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            return data;
        }

        public async Task DeleteUser(int Id)
        {
            try
            {
                var user = await _dbContext.User.Where(x => x.Id == Id).FirstOrDefaultAsync();
                if (user != null)
                {
                    _dbContext.Remove(user);
                    await _dbContext.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {

                Debug.WriteLine(e.Message);
            }
        }

        public async Task UpdateUser(User user)
        {
            try
            {

                var oldUserData = await _dbContext.User.Where(x => x.Id == user.Id).FirstOrDefaultAsync();
                if (oldUserData != null)
                {

                    oldUserData.Id = user.Id;
                    oldUserData.Name = user.Name;
                    oldUserData.Email = user.Email;
                    oldUserData.Address = user.Address;
                    oldUserData.Gender = user.Gender;
                    oldUserData.Mobile = user.Mobile;
                    oldUserData.HobbyId = user.HobbyId;
                    oldUserData.StateId = user.StateId;
                    _dbContext.User.Update(oldUserData);
                    await _dbContext.SaveChangesAsync();
                }

            }
            catch (Exception e)
            {

                Debug.WriteLine(e.Message);
            }


        }

    }
}

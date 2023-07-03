using DinnerWithMe.Application.Common.Interfaces.Persistence;
using DinnerWithMe.Domain.Entities;

namespace DinnerWithMe.Infrastructure.Presistence;

public class UserRepository : IUserRepository
{
      private static readonly List<User> users = new();
      
      public void AddUser(User user)
      {
        users.Add(user);
      }

      public User? GetUserByEmail(string email)
      {
            return users.SingleOrDefault(user => user.Email == email);
      }
}

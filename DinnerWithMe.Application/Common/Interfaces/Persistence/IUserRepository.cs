
using DinnerWithMe.Domain.Entities;

namespace DinnerWithMe.Application.Common.Interfaces.Persistence;
public interface IUserRepository
{
    void AddUser(User user);
    User? GetUserByEmail(string email);
}

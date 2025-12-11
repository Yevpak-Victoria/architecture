using Library.Domain.Entities;
using System.Linq.Expressions;

namespace Library.Domain.Interfaces;

public interface IUserRepository : IRepository<User>
{
    // додаткові методи специфічні для User можна додати сюди
}

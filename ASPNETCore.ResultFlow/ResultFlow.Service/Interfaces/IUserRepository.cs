using ResultFlow.Core.Entity;

namespace ResultFlow.Core.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetByIdAsync(int id);
    }
}

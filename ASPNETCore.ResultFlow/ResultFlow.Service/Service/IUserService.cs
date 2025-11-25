using ResultFlow.Core.Common;
using ResultFlow.Core.Entity;

namespace ResultFlow.Core.Service
{
    public interface IUserService
    {
        Task<Result<User>> GetUserAsync(int id);
    }
}

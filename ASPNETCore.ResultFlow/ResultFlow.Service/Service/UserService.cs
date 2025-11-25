using ResultFlow.Core.Common;
using ResultFlow.Core.Entity;
using ResultFlow.Core.Interfaces;

namespace ResultFlow.Core.Service
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Result<User>> GetUserAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);

            if (user is null)
                return Result<User>.Fail("User not found", ErrorCode.NotFound);

            if (!user.Active)
                return Result<User>.Fail("User inactive", ErrorCode.BusinessRule);

            return Result<User>.OK(user);
        }        
    }
}

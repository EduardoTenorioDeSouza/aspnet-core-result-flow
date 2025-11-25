using Dapper;
using ResultFlow.Core.Entity;
using ResultFlow.Core.Interfaces;
using System.Data;

namespace ResultFlow.Infra
{
    public class UserRepository : IUserRepository
    {
        private IDbConnection _db;

        public UserRepository(IDbConnection db)
        {
            _db = db;
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await _db.QueryFirstOrDefaultAsync<User>(
                "SELECT * FROM Users WHERE Id = @id",
                new { id });
        }
    }
}

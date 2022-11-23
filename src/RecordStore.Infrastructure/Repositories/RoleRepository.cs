using Microsoft.EntityFrameworkCore;
using RecordStore.Core.Entities.Identity;
using RecordStore.Core.Interfaces;
using RecordStore.Infrastructure.Data;

namespace RecordStore.Infrastructure.Repositories
{
    public class RoleRepository : GenericRepository<Role>, IRoleRepository
    {
        public RoleRepository(ApplicationDbContext context) : base(context) { }

        public async Task<IReadOnlyCollection<Role>> GetUserRolesAsync(Guid userId)
        {
            return await (
                from user in _context.Users
                where user.Id == userId
                join userRoles in _context.UserRoles on user.Id equals userRoles.UserId
                join role in _context.Roles on userRoles.RoleId equals role.Id
                select role)
                .ToListAsync();
        }
    }
}

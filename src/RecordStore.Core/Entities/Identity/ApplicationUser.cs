
using Microsoft.AspNetCore.Identity;

namespace RecordStore.Core.Entities.Identity
{
    public class ApplicationUser : IdentityUser<Guid>, IEntity
    {
        public DateTimeOffset CreateDate { get; set; } = DateTimeOffset.UtcNow;
    }
}

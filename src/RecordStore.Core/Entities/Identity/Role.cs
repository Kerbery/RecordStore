
using Microsoft.AspNetCore.Identity;

namespace RecordStore.Core.Entities.Identity
{
    public class Role : IdentityRole<Guid>, IEntity
    {
        public DateTimeOffset CreateDate { get; set; } = DateTimeOffset.Now;
    }
}

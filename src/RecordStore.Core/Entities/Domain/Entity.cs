using System.ComponentModel.DataAnnotations;

namespace RecordStore.Core.Entities.Models
{
    public abstract class Entity : IEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTimeOffset CreateDate { get; set; } = DateTimeOffset.Now;
    }
}

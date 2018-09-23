using System.ComponentModel.DataAnnotations;

namespace FeedAggregator.DAL.Entities
{
    public abstract class Entity
    {
        [Key]
        public virtual int Id { get; set; }
    }
}

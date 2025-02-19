namespace Tourmine.Tournament.Domain.Entities
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }

        public BaseEntity()
        {
            Id = Guid.NewGuid();
            CreatedDate = DateTimeOffset.Now; 
        }

        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset? ModifiedDate { get; set; }
    }
}

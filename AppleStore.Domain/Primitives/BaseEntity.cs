using AppleStore.Domain.Notifications;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppleStore.Domain.Primitives
{
    public abstract class BaseEntity
    {
        protected BaseEntity()
        {
            Id = Guid.NewGuid();
        }

        private List<Notification>? _notifications;

        [Key]
        public Guid Id { get; protected init; }

        public override bool Equals(object? obj)
        {
            if (obj is null)
                return false;

            if (obj.GetType() != GetType())
                return false;

            if (obj is not BaseEntity entity)
                return false;

            return entity.Id == Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        private DateTime _createAt;

        public DateTime CreateAt
        {
            get { return _createAt; }
            set { _createAt = DateTime.UtcNow; }
        }

        private DateTime? _updateAt;

        public DateTime? UpdateAt
        {
            get { return _updateAt; }
            set { _updateAt = value; }
        }

        [NotMapped]
        public IReadOnlyCollection<Notification> Notifications => _notifications;

        protected void SetNotifications(List<Notification> notifications)
        {
            _notifications = notifications;
        }

        public abstract bool IsValid();
    }
}

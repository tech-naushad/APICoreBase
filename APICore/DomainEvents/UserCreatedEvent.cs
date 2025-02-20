using MediatR;

namespace APICore.DomainEvents
{
    public class UserCreatedEvent : INotification
    {
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public UserCreatedEvent(string name, string userName, string email)
        {
            Name = name;
            UserName = userName;
            Email = email;
        }
    }
}

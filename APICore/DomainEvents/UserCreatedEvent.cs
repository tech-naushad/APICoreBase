using MediatR;

namespace APICore.DomainEvents
{
    public class UserCreatedEvent : INotification
    {
        public string Email { get; set; }
        public string Mobile { get; set; }
        public UserCreatedEvent(string email,string mobile)
        {
            Email = email;
            Mobile = mobile;
        }
    }
}

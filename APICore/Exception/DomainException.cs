using System;
namespace APICore.Exception
{
    public class DomainException : System.Exception
    {
        public DomainException(string message): base(message)
        {
            
        }
        public DomainException(string message, System.Exception exception)
        {
            
        }
    }
}

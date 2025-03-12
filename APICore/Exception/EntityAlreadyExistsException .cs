using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APICore.Exception
{
    public class EntityAlreadyExistsException : DomainException
    {
        public EntityAlreadyExistsException(string entityName)
        : base($"{entityName} exists already")
        {}
    }
}

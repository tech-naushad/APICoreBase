using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APICore.Exception
{
    public class EntityNotFoundException:DomainException
    {
        public EntityNotFoundException(string entityName, object key)
        : base($"{entityName} with value {key} was not found.")
        {
        }
    }
}

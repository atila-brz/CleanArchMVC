using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMVC.Domain.Validations
{
    public class DomainExceptionsValidations : Exception
    {
        public DomainExceptionsValidations(string error) : base(error) { }

        public static void When(bool hasError, string error)
        {
            if(hasError)
            {
                throw new DomainExceptionsValidations(error);
            }
        }

    }
}

using AdmissionContestCS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsmissionContestCS.Domain
{
    class ValidatorSectie : IValidator<Sectie>
    {
        public void validate(Sectie item)
        {
            string msg = "";
            
            if ( "" == item.Nume )
            {
                msg+="Numele nu poate fi vid!\n";
            }
            if (0 >= item.NrLoc)
            {
                msg += "Numarul de locuri trebuie sa > 0!\n";
            }
            if (msg != "")
            {
                throw new CustomException(msg);
            }
        }
    }
}

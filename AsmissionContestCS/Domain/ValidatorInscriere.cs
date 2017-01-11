using AsmissionContestCS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmissionContestCS
{
    class ValidatorInscriere : IValidator<Inscriere>
    {
        public void validate(Inscriere item)
        {
            string msg = "";

            if (item.IdC <= 0)
            {
                msg+="Id-ul candidatului trebuie sa fie un numar natural!\n";
            }
            if (item.IdS <= 0)
            {
                msg += "Id-ul sectiei trebuie sa fie un numar natural!\n";
            }
            if (msg != "")
            {
                throw new CustomException(msg);
            }
        }
    }
}

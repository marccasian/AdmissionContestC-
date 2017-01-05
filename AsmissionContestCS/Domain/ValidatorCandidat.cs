using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmissionContestCS
{
    class ValidatorCandidat : IValidator<Candidat>
    {
        public void validate(Candidat item)
        {
            string msg = "";

            if (item.Nume == "")
            {
                msg+="Numele nu poate fi vid!\n";
            }
            if (item.Adresa == "")
            {
                msg+="Adresa nu poate fi vida!\n";
            }
            if (item.Varsta < 1)
            {
                msg+="Varsta trebuie sa fie pozitiva!\n";
            }
            if (item.Telefon.Length != 10)
            {
                msg+="Numarul de telefon trebuie sa aiba lungimea 10!\n";
            }
            if (msg != "")
            {
                throw new CustomException(msg);
            }
        }
    }
}

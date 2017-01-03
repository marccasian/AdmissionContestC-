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
            StringBuilder msg = new StringBuilder();

            if (item.Nume == "")
            {
                msg.Append("Numele nu poate fi vid!\n");
            }
            if (item.Adresa == "")
            {
                msg.Append("Adresa nu poate fi vida!\n");
            }
            if (item.Varsta < 1)
            {
                msg.Append("Varsta trebuie sa fie pozitiva!\n");
            }
            if (item.Telefon.Length != 10)
            {
                msg.Append("Numarul de telefon trebuie sa aiba lungimea 10!\n");
            }
        }
    }
}

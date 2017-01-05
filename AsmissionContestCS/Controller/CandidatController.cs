using AdmissionContestCS;
using AdmissionContestCS.Domain;
using AdmissionContestCS.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace AsmissionContestCS.Controller
{
    class CandidatController:AbstractController<Candidat, int>
    {
        public CandidatController(IRepository<Candidat,int> repo, ValidatorCandidat cvali) : base(repo,cvali) { }

        public Candidat Save(string nume, string adresa, string varsta, string nrTel)
        {
            int nr;
            Candidat c;
            if (int.TryParse(varsta, out nr))
            {
                c = new Candidat(GetNewId(), nume, adresa, nr, nrTel);
                base.Validator.validate(c);
                return Repository.Save(c);
            }
            else
            {
                throw new CustomException("Varsta trebuie sa fie un numar natural!");
            }
        }

        public Candidat Remove(string id)
        {
            int id_del;
            if (int.TryParse(id, out id_del))
            {
                return Repository.Remove(id_del);
            }
            else
            {
                throw new CustomException("ID-ul trebuie sa fie un numar natural!");
            }
        }

        private int GetNewId()
        {
            int maxx = -1;
            foreach (Candidat c in GetAll())
            {
                if (c.Id > maxx) maxx = c.Id;
            }
            return maxx + 1;
        }

        public Candidat Update(string id_mod, string nume, string adresa, string varsta, string nrTel)
        {
            int id_modif;
            if (int.TryParse(id_mod, out id_modif))
            {
                int vrst;
                if (int.TryParse(varsta, out vrst))
                {
                    Candidat c = new Candidat(id_modif, nume, adresa, vrst, nrTel);
                    return Repository.Update(c);
                }
                else
                {
                    throw new CustomException("Varsta trebuie sa fie numar natural!");
                }
            }
            else
            {
                throw new CustomException("ID-ul trebuie sa fie numar natural!");
            }
        }
    }
}

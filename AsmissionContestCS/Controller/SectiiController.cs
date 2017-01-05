using AdmissionContestCS;
using AsmissionContestCS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace AsmissionContestCS.Controller
{
    class SectiiController:AbstractController<Sectie, int>
    {
        public SectiiController(IRepository<Sectie, int> repo, ValidatorSectie svali): base(repo, svali) { }

        public Sectie Save(string nume, string nrLoc) {
            int nr;
            Sectie s;
            if ( int.TryParse(nrLoc, out nr)){
                s = new Sectie(GetNewId(), nume, nr);
                base.Validator.validate(s);
                return Repository.Save(s);
            }
            else
            {
                throw new CustomException("Numarul de locuri trebuie sa fie un numar natural!");
            }
        }

        public Sectie Remove(string id)
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
            foreach (Sectie s in GetAll())
            {
                if (s.Id > maxx) maxx = s.Id;
            }
            return maxx + 1;
        }

        public Sectie Update(string id_mod, string nume, string nrLoc)
        {
            int id_modif;
            if (int.TryParse(id_mod, out id_modif))
            {
                int nr;
                if (int.TryParse(nrLoc, out nr))
                {
                    Sectie s = new Sectie(id_modif, nume, nr);
                    return Repository.Update(s);
                }
                else
                {
                    throw new CustomException("Numarul de locuri trebuie sa fie numar natural!");
                }
            }
            else
            {
                throw new CustomException("ID-ul trebuie sa fie numar natural!");
            }
        }
    }
}

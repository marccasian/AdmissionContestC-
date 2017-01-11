using AdmissionContestCS;
using AdmissionContestCS.Domain;
using AdmissionContestCS.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using AsmissionContestCS.Domain;

namespace AsmissionContestCS.Controller
{
    class InscrieriController:AbstractController<Inscriere, int>
    {
        public InscrieriController(IRepository<Inscriere,int> repo, ValidatorInscriere cvali) : base(repo,cvali) { }

        public Inscriere Save(int IdS, int IdC)
        {
            Inscriere c;
            c = new Inscriere(GetNewId(), IdS, IdC);
            base.Validator.validate(c);
            return Repository.Save(c);
        }

        public Inscriere Remove(string id)
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
            foreach (Inscriere c in GetAll())
            {
                if (c.Id > maxx) maxx = c.Id;
            }
            return maxx + 1;
        }
    }
}

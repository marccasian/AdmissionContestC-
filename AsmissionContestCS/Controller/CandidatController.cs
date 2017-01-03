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
        public CandidatController(IRepository<Candidat,int> repo) : base(repo) { }

    }
}

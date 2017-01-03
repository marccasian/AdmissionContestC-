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
        public SectiiController(IRepository<Sectie, int> repo): base(repo) { }

    }
    
}

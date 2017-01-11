using AdmissionContestCS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsmissionContestCS.Domain
{
    class Inscriere:IHasID<int>
    {
        public int Id { set; get; }
        public int IdS { get; set; }
        public int IdC { get; set; }

        public Inscriere()
        {
            this.Id = -1;
            this.IdS = -1;
            this.IdC = -1;
        }

        public Inscriere(int Id, int IdS, int IdC)
        {
            this.Id = Id;
            this.IdS = IdS;
            this.IdC = IdC;
        }

        public override string ToString()
        {
            return "InscriereID=" + this.Id.ToString() + " SectieID=" + this.IdS.ToString() + " CandidatID=" + this.IdC.ToString();
        }
    }
}

using AdmissionContestCS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsmissionContestCS.Domain
{
    class Sectie:IHasID<int>
    {
        public int Id { set; get; }
        public string Nume { set; get; }
        public int NrLoc { set; get; }

        public Sectie(int Id, string Nume, int NrLoc)
        {
            this.Id = Id;
            this.Nume = Nume;
            this.NrLoc = NrLoc;
        }

        public override string ToString()
        {
            return Nume + " " + NrLoc.ToString();
        }
    }   
}

using AdmissionContestCS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmissionContestCS
{
    class Candidat:IHasID<int>
    {

        public int Id { set; get; }
        public string Nume  { set; get; }
        public string Adresa { set; get; }
        public int Varsta { set; get; }
        public string Telefon { set; get; }

        public Candidat(int Id, string Nume, string Adresa, int Varsta, string Telefon)
        {
            this.Id = Id;
            this.Nume = Nume;
            this.Adresa = Adresa;
            this.Varsta = Varsta;
            this.Telefon = Telefon;
        }

        public override string ToString()
        {
            return Nume + ' ' + Varsta.ToString();
        }
    }
}

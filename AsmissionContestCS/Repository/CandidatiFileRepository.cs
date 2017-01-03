using AdmissionContestCS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AsmissionContestCS.Repository
{
    class CandidatiFileRepository : AbstractFileRepository<Candidat, int>
    {

        public CandidatiFileRepository(string file) : base(file) { }
        
        public override void LoadFromFile()
        {
            if (!File.Exists(base.FileName))
            {
                throw new FileNotFoundException("Fisierul: " + base.FileName + " nu exista!");
            }
            using (StreamReader rd = new StreamReader(base.FileName))
            {
                string line = rd.ReadLine();
                string[] attrs = line.Split(';');
                Candidat c = new Candidat(int.Parse(attrs[0]), attrs[1], attrs[2], int.Parse(attrs[3]), attrs[4]);
                base.all.Add(c);
            }
        }

        public override void WriteToFile()
        {
            if (!File.Exists(base.FileName))
            {
                throw new FileNotFoundException("Fisierul: " + base.FileName + " nu exista!");
            }
            using (StreamWriter wr = new StreamWriter(base.FileName))
            {
                foreach (Candidat c in all)
                {
                    wr.WriteLine(c.Id.ToString() + ';' + c.Nume + ';' + c.Adresa + ';' + c.Varsta.ToString() + ';' + c.Telefon);
                }
            }
        }
    }
}

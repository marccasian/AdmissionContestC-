using AsmissionContestCS.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsmissionContestCS.Repository
{
    class InscrieriFileRepository:AbstractFileRepository<Inscriere, int>
    {
        public InscrieriFileRepository(string file) : base(file) {}

        public override void LoadFromFile()
        {
            if (!File.Exists(base.FileName))
            {
                throw new FileNotFoundException("Fisierul: " + base.FileName + " nu exista!");
            }
            using (StreamReader rd = new StreamReader(base.FileName))
            {
                while (!rd.EndOfStream)
                {
                    string line = rd.ReadLine();
                    string[] attrs = line.Split(';');
                    Inscriere i = new Inscriere(int.Parse(attrs[0]), int.Parse(attrs[1]), int.Parse(attrs[2]));
                    base.all.Add(i);
                }
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
                foreach (Inscriere i in all)
                {
                    wr.WriteLine(i.Id.ToString() + ';' + i.IdS.ToString() + ';' + i.IdC.ToString());
                }
            }
        }
    }
}

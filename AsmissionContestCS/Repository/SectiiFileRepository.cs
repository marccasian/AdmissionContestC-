using AsmissionContestCS.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsmissionContestCS.Repository
{
    class SectiiFileRepository : AbstractFileRepository<Sectie, int>
    {
        public SectiiFileRepository(string file): base(file) {}

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
                    Sectie s = new Sectie(int.Parse(attrs[0]), attrs[1], int.Parse(attrs[2]));
                    base.all.Add(s);
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
                foreach (Sectie s in all)
                {
                    wr.WriteLine(s.Id.ToString() + ';' + s.Nume + ';' + s.NrLoc.ToString());
                }
            }
        }
    }
}

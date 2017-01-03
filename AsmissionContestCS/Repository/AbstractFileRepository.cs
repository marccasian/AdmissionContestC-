using AdmissionContestCS.Domain;
using AdmissionContestCS.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsmissionContestCS.Repository
{
    abstract class AbstractFileRepository<E,Id> : InMemoryRepository<E,Id> where E : IHasID<Id>
    {
        protected string FileName { get; set; }
        public AbstractFileRepository(string fileName)
        {
            FileName = fileName;
            LoadFromFile();
        }

        public abstract void LoadFromFile();
        public abstract void WriteToFile();

        public override E Save(E entity)
        {
            E e = base.Save(entity);
            WriteToFile();
            return e;
        }
    }
}

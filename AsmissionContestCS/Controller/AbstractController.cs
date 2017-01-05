using AdmissionContestCS;
using AdmissionContestCS.Domain;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsmissionContestCS.Controller
{
    abstract class AbstractController<E, Id> : IController<E, Id> where E : IHasID<Id>
    {
        protected IRepository<E, Id> Repository;
        protected IValidator<E> Validator;

        public AbstractController(IRepository<E, Id> repo, IValidator<E> vali)
        {
            this.Repository = repo;
            this.Validator = vali;
        }

        public IEnumerable GetAll()
        {
            return Repository.GetAll();
        }

        public E Remove(Id id)
        {
            try
            {
                E cc = Repository.Remove(id);
                return cc;
            }
            catch (CustomException e)
            {
                Console.WriteLine(e.Message);
                return default(E);
            }
        }

        public E Save(E entity)
        {
            try
            {
                E ee = Repository.Save(entity);
                return ee;
            }
            catch (CustomException e)
            {
                Console.WriteLine(e.Message);
                return default(E);
            }
        }

        public E Update(E entity)
        {
            try
            {
                E ee = Repository.Update(entity);
                return ee;
            }
            catch (CustomException e)
            {
                Console.WriteLine(e.Message);
                return default(E);
            }
        }

    }
}

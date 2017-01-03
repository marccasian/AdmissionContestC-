using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdmissionContestCS.Domain;

namespace AdmissionContestCS.Repository
{
    class InMemoryRepository<E, Id> : IRepository<E, Id> where E : IHasID<Id>
    {

        protected List<E> all = new List<E>();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>return entity or default </returns>
        public E FindOne(Id id)
        {
            foreach (E e in all){
                if (e.Id.Equals(id))
                {
                    return e;
                }
            }
            return default(E);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<E> GetAll()
        {
            return all;
        }

        public virtual E Remove(Id id)
        {
            E e = FindOne(id);
            if (null != e) all.Remove(e);
            return e;
        }

        public virtual E Save(E entity)
        {
            E e = FindOne(entity.Id);
            if (null == e) {
                all.Add(entity);
                return e;
            }
            return entity;
        }

        public virtual E Update(E entity)
        {
            E e = FindOne(entity.Id);
            if (null != e)
            {
                all.Remove(e);
                all.Add(entity);
                return e;
            }
            return default(E);
        }
    }
}

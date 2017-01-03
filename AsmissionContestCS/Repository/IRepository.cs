using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdmissionContestCS.Domain;

namespace AdmissionContestCS
{
    interface IRepository<E , Id> where E : IHasID<Id>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns>
        /// Totate entitatiile din repository
        /// </returns>

        IEnumerable<E> GetAll();

        /// <summary>
        /// Salveaza o entitate in repository
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>
        /// null - entitatea a fost salvata
        /// entitatea - entitatea exista in repository
        /// </returns>
        E Save (E entity);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        E Remove(Id id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        E FindOne(Id id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        E Update(E entity);
    }
}

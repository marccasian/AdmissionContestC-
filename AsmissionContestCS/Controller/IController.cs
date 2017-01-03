using AdmissionContestCS.Domain;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsmissionContestCS.Controller
{
    interface IController<E, Id> where E : IHasID<Id> { 
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IEnumerable GetAll();
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        E Save(E entity);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        E Remove(Id id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        E Update(E entity);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmissionContestCS.Domain
{
    interface IHasID<T>
    {
        T Id { set; get; }
    }
}

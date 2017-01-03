using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmissionContestCS
{
    class CustomException:ApplicationException
    {
        public CustomException(string msg) : base(msg) { }
    }
}

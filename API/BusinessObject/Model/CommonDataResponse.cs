using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.BadVersion.Models
{
    internal class CommonResultResponse<T>
    {
        public bool Status { get; set; }
        public T Result { get; set; }
    }
}

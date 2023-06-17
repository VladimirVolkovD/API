using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.BadVersion.Models
{
    internal class CommonDataResponse<T>
    {
        public T Data { get; set; }
    }
}

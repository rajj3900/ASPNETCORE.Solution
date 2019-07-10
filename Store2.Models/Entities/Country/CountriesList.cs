using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store2.Domain.Country
{
    public class CountriesList : BaseModel
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}

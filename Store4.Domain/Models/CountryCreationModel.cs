using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store4.Domain.Models
{
    public class CountryCreationModel : BaseModel
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}

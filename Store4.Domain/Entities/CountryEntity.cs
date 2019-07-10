using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store4.Domain.Entities
{
    public class CountryEntity : BaseEntity
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string CreatedUser { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}

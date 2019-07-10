using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store4.Domain.Entities
{
    public class StoreEntity : BaseEntity
    {
        public string StoreCode { get; set; }
        public string StoreName { get; set; }
        public System.Guid CountryId { get; set; }
        public string CreatedUser { get; set; }
        public System.DateTime CreatedDate { get; set; }
    }
}

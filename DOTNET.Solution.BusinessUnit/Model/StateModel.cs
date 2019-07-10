using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOTNET.Solution.BusinessUnit.Model
{
    public class StateModel : BaseDataModel
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public System.Guid CountryId { get; set; }
        public string Name { get; set; }
    }
}

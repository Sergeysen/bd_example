using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bd_lab4.entity
{
    public class Enterprise
    {
        public int RegistrationNumber { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Industry { get; set; }
        public string FormOfOwnership { get; set; }
    }
}

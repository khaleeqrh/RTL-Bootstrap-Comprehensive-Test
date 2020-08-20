using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RTL_Bootstrap_Comprehensive_Test.Models
{
    public class PersonModel
    {
        public int Id { get; set; }

        public String FirstName { get; set; }

        public String LastName { get; set; }

        public String EmailAddress { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}

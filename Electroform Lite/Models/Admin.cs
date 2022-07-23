using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electroform_Lite.Models
{
    internal class Admin : User
    {
        public Admin(string name, string password) : base(name, password)
        {
            
        }
    }
}

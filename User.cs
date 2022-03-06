using System;
using SQLite;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino
{
    internal class User
    {
        [PrimaryKey]
        public string Name { get; set; }
        public string Password { get; set; }
        public double Money { get; set; }
    }
}

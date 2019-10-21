using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EserciziADO.Helpers
{
    public class DbHelper
    {
        public string ConnectionString { get; private set; }

        public DbHelper(string connectionString)
        {
            ConnectionString = connectionString;
        }
    }
}

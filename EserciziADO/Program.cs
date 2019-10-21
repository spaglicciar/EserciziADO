using EserciziADO.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EserciziADO
{
    class Program
    {
        static void Main(string[] args)
        {
            InitDb();

            var persone = DbHelper.GetPersone();
            DataTable table = persone.Tables[0];

            foreach (DataRow row in table.Rows)
            {
                {
                    Console.WriteLine("{0} {1} {2} {3}", row[0], row[1], row[2], row[3]);
                }
            }
        }

        static void InitDb()
        {
            List<Persona> listP = new List<Persona>
            {
                new Persona("Lord", "Voldemort", new DateTime(1926, 12, 31)),
                new Persona("Harry", "Potter", new DateTime(1980, 7, 31))
            };

            foreach(var p in listP)
            {
                DbHelper.InsertPersona(p);
            }
        }
    }
}

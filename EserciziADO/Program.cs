using EserciziADO.Helpers;
using System;
using System.Collections.Generic;
using System.Data;

namespace EserciziADO
{
    class Program
    {
        static void Main(string[] args)
        {
            //InitDb();

            DataSet ds = DbHelper.GetPersone();

            Console.WriteLine("Estrazione prima dell'update");
            PrintDataSet(ds);

            Guid guid = new Guid("032D068A-EF7E-4C95-A8A3-6A4C4D34B440");

            Lavoratore lav = new Lavoratore
            {
                Persona_ID = guid,
                Nome = "Roberto",
                Cognome = "Baggio",
                DataDiNascita = new DateTime(1983, 7, 3),
                Tipo = TipoLavoratore.Dipendente,
                DataDiAssunzione = new DateTime(2014, 3, 17),
                Retribuzione = 35000
            };

            //update Roberto Spagliccia in Roberto Baggio con guid "032D068A-EF7E-4C95-A8A3-6A4C4D34B440"
            DbHelper.UpdatePersona(lav);

            //stampo a schermo contenuto tabella
            ds = DbHelper.GetPersone();
            Console.WriteLine("Estrazione dopo l'update");
            PrintDataSet(ds);

            //cancello Roberto Baggio dopo averlo aggiornato
            DbHelper.DeletePersona(lav);

            //stampo a schermo contenuto tabella
            ds = DbHelper.GetPersone();
            Console.WriteLine("Estrazione dopo il delete");
            PrintDataSet(ds);

            //svuoto tabella lavoratori
            DbHelper.SvuotaTabella("Lavoratori");

            //stampo a schermo contenuto tabella
            ds = DbHelper.GetPersone();
            Console.WriteLine("Estrazione dopo il delete della tabella");
            PrintDataSet(ds);

            Console.ReadLine();
        }

        private static void PrintDataSet(DataSet ds)
        {
            DataTable dt = ds.Tables[0];

            foreach (DataRow row in dt.Rows)
            {
                Console.WriteLine("{0}, {1}, {2}, {3}, {4}, {5}, {6}", row[0], row[1], row[2], row[3], row[4], row[5], row[6]);
            }
        }

        private static void InitDb()
        {
            List<Lavoratore> listaL = new List<Lavoratore>
            {
                new Lavoratore
                {
                    Nome = "Roberto",
                    Cognome = "Spagliccia",
                    DataDiNascita = new DateTime(1983, 7, 3),
                    Tipo = TipoLavoratore.Dipendente,
                    DataDiAssunzione = new DateTime(2014, 3, 17),
                    Retribuzione = 3500
                },
                new Lavoratore
                {
                    Nome = "Pippo",
                    Cognome = "Baudo",
                    DataDiNascita = new DateTime(1936, 12, 3),
                    Tipo = TipoLavoratore.Dipendente,
                    DataDiAssunzione = new DateTime(1982, 3, 17),
                    Retribuzione = 8000
                },
                new Lavoratore
                {
                    Nome = "Lord",
                    Cognome = "Voldemort",
                    DataDiNascita = new DateTime(1926, 12, 31),
                    Tipo = TipoLavoratore.Dipendente,
                    DataDiAssunzione = new DateTime(1955, 3, 17),
                    Retribuzione = 3500000
                }

            };

            foreach (var l in listaL)
            {
                DbHelper.InsertPersona(l);
            }
        }
    }
}

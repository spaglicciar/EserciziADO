using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EserciziADO
{
    class Persona
    {
        public int Persona_ID { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public DateTime DataDiNascita { get; set; }

        public override string ToString()
        {
            return string.Format("Nome: {0}, Cognome: {1}, Data di nascita: {2:d}", Nome, Cognome, DataDiNascita);
        }


    }
}

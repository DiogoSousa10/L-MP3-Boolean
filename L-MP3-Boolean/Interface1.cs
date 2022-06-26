using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L_MP3_Boolean
{
    internal interface Interface1
    {

        List<Implementacao> Dados { get; set; }

        event MetodosSemParametros SalaReservada;
        void LeituraXML(string ficheiro);
        void EscritaXML(string ficheiro);
        void ProcurarMaior(string titulo);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace jogoEmprestado.Models
{
    public class Jogo
    {
        public string nome { get; set; }
        public string consolePc { get; set; }
        //data prometida da devolução ao amigo
        public DateTime entrega { get; set; }
    }
}

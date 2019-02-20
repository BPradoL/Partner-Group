using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class Patrimonio
    {
        public int MarcaId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int NTombo { get; set; }
    }
}
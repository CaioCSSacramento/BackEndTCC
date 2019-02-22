using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webServiceTCC.Models
{
    public class Aluno
    {
        public string alun_cpf { get; set; }
        public string alun_nome { get; set; }
        public string alun_endereco { get; set; }
        public string alun_estado { get; set; }
        public string alun_municipio { get; set; }
        public string alun_telefone { get; set; }
        public string alun_email { get; set; }
        public string alun_senha { get; set; }
    }
}
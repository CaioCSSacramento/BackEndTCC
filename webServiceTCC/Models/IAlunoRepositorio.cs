using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace webServiceTCC.Models
{
    interface IAlunoRepositorio
    {
        Aluno GetUsuario(string email, string senha);
    }
}

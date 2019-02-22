using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using webServiceTCC.Models;

namespace webServiceTCC.Controllers
{
    public class AlunoController : ApiController
    {

        static readonly IAlunoRepositorio alunoRepositorio = new AlunoRepositorio();

        //Metodo do webService que vai retornar os dados do usuário.
        public HttpResponseMessage GetAutenticar(string email, string senha)
        {
            Aluno aluno = alunoRepositorio.GetUsuario(email, senha);
            if (aluno == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Credenciais inválidas.");
            }
            else
            {
                return Request.CreateResponse<Aluno>(HttpStatusCode.OK, aluno);
            }
        }
    }
}

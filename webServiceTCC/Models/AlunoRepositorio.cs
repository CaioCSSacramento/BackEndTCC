using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace webServiceTCC.Models
{
    public class AlunoRepositorio : IAlunoRepositorio
    {
        public Aluno GetUsuario(string email, string senha)
        {
            StringBuilder vSql = new StringBuilder();
            MySqlConnection vConexao;
            MySqlCommand vComando;
            MySqlDataReader vDrd;
            Aluno vAluno = new Aluno();

            //conecta ao banco local, que está no servidor da amazon e busca os dados do usuário
            using (vConexao = new MySqlConnection("Server=localhost;Database=mydb;Uid=root;Pwd=masterkey1;"))
            {
                vConexao.Open();

                try
                {
                    vSql.Remove(vSql.Length, 0);
                    vSql.Append("Select * from aluno where ALUN_EMAIL = @email and ALUN_SENHA = @senha ");
                    using (vComando = new MySqlCommand(vSql.ToString(), vConexao))
                    {
                        vComando.Parameters.Add("@email", MySqlDbType.VarChar).Value = email;
                        vComando.Parameters.Add("@senha", MySqlDbType.VarChar).Value = senha;

                        using (vDrd = vComando.ExecuteReader())
                        {
                            if (vDrd.Read())
                            {
                                vAluno.alun_cpf = vDrd["alun_cpf"].ToString();
                                vAluno.alun_nome = vDrd["alun_nome"].ToString();
                                vAluno.alun_endereco = vDrd["alun_endereco"].ToString();
                                vAluno.alun_estado = vDrd["alun_estado"].ToString();
                                vAluno.alun_municipio = vDrd["alun_municipio"].ToString();
                                vAluno.alun_telefone = vDrd["alun_telefone"].ToString();
                                vAluno.alun_email = vDrd["alun_email"].ToString();
                                vAluno.alun_senha = vDrd["alun_senha"].ToString();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                MySqlConnection.ClearAllPools();

                return vAluno;

            }

        
        }
    }
}
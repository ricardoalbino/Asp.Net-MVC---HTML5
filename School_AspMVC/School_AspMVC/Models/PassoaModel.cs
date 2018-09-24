using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace School_AspMVC.Models
{
    public class PessoaModel
    {
        public int id { get; set; }

        [Required(ErrorMessage = "O nome da pessoa deve ser informado.!")]
        [StringLength(50, MinimumLength = 5)]
        public string nome { get; set; }

        [Required(ErrorMessage = "O endereço da pessoa deve ser informado.!")]
        [StringLength(50, MinimumLength = 5)]
        public string endereco { get; set; }

        [Required(ErrorMessage = "O email da pessoa deve ser informado.!")]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }



        public void Create(PessoaModel pessoaModel)
        {


            string sql = "INSERT INTO PESSOA(NOME, ENDERECO, EMAIL) VALUES(@NOME, @ENDERECO, @EMAIL)";

            SqlCommand comando = new SqlCommand(sql, Conexao.Conectar());
           // comando.Parameters.AddWithValue("@ID", pessoaModel.id);
            comando.Parameters.AddWithValue("@NOME", pessoaModel.nome);
            comando.Parameters.AddWithValue("@ENDERECO", pessoaModel.endereco);
            comando.Parameters.AddWithValue("@EMAIL", pessoaModel.email);


            try
            {
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public List<PessoaModel> GetAll()
        {
            string sql = "SELECT * FROM PESSOA";

            List<PessoaModel> lista = new List<PessoaModel>();

           SqlCommand command = new SqlCommand(sql, Conexao.Conectar());
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                lista.Add(new PessoaModel
                {

                    id = Convert.ToUInt16(reader["Id"]),
                    nome = reader["nome"].ToString(),
                    endereco = reader["endereco"].ToString(),
                    email = reader["email"].ToString()
                });
            }

 
            return lista;
        }

        public PessoaModel GetByID(int id)
        {
            string sql = "select * from pessoa where id = @id";

            PessoaModel pessoaModel = new PessoaModel();

            SqlCommand command = new SqlCommand(sql, Conexao.Conectar());
            command.Parameters.AddWithValue("@id", id);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                pessoaModel.id = Convert.ToUInt16(reader["Id"]);
                pessoaModel.nome = reader["nome"].ToString();
                pessoaModel.endereco = reader["endereco"].ToString();
                pessoaModel.email = reader["email"].ToString();
            }


            return pessoaModel;
        }

        public  void Update(PessoaModel pessoaModel)
        {


            string sql = "UPDATE Pessoa SET Nome=@NOME, Endereco=@ENDERECO, Email=@EMAIL Where Id=@ID";

            SqlCommand comando = new SqlCommand(sql, Conexao.Conectar());
            comando.Parameters.AddWithValue("@ID", pessoaModel.id);
            comando.Parameters.AddWithValue("@NOME", pessoaModel.nome);
            comando.Parameters.AddWithValue("@ENDERECO", pessoaModel.endereco);
            comando.Parameters.AddWithValue("@EMAIL", pessoaModel.email);
         

            try
            {
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void Deletar(int id)
        {
            string sql = "DELETE FROM PESSOA WHERE ID=@id";
            SqlCommand comando = new SqlCommand(sql, Conexao.Conectar());
            comando.Parameters.AddWithValue("@id", id);
            try
            {
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
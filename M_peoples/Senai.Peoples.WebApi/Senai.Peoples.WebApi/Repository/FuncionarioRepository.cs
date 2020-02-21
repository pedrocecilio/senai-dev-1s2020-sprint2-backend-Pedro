using Senai.Peoples.WebApi.Domains;
using Senai.Peoples.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Repository
{
    public class FuncionarioRepository : IFuncionarioRepository
    {

        private string connection = "Data Source = DEV21\\SQLEXPRESS;initial catalog= M_Peoples; user Id=sa; pwd=sa@132";

        public List<FuncionarioDomain> List()
        {

            List<FuncionarioDomain> funcionarios = new List<FuncionarioDomain>();

            using (SqlConnection conn = new SqlConnection(connection))
            {
                string queryVisuAll = "SELECT IdFuncionario, Nome, Sobrenome FROM Funcionarios";

                conn.Open();

                SqlDataReader reader;

                using (SqlCommand cmmd = new SqlCommand(queryVisuAll, conn))
                {
                    reader = cmmd.ExecuteReader();

                    while (reader.Read())
                    {
                        FuncionarioDomain funcionario = new FuncionarioDomain
                        {
                            IdFuncionario = Convert.ToInt32(reader[0]),

                            Nome = (reader[1]).ToString(),

                            Sobrenome = (reader[2]).ToString(),

                        };

                        funcionarios.Add(funcionario);
                    }
                    return funcionarios;

                }

            }

        }

        public FuncionarioDomain SearchId(int id)
        {
            using (SqlConnection conn = new SqlConnection(connection))
            {
                string querySelectbyId = "SELECT IdFuncionario, Nome, Sobrenome FROM Funcionarios WHERE IdFuncionario = @ID" ;

                conn.Open();

                SqlDataReader reader;

                using (SqlCommand cmmd = new SqlCommand(querySelectbyId, conn))
                {
                    cmmd.Parameters.AddWithValue("@ID", id);

                    reader = cmmd.ExecuteReader();

                    if (reader.Read())
                    {
                        FuncionarioDomain funcionario = new FuncionarioDomain
                        {

                            IdFuncionario = Convert.ToInt32(reader["IdFuncionario"]),

                            Nome = reader["Nome"].ToString(),

                            Sobrenome = reader["Sobrenome"].ToString()

                        };

                        return funcionario;
                    }

                    return null;
                }

            }
        }

        public void Insert(FuncionarioDomain funcionario)
        {
            using (SqlConnection conn = new SqlConnection(connection))
            {
                string queryInsert = "INSERT INTO Funcionarios(Nome, Sobrenome) VALUES (@Nome, @Sobrenome)";

                SqlCommand cmmd = new SqlCommand(queryInsert, conn);

                cmmd.Parameters.AddWithValue("@Nome", funcionario.Nome);

                cmmd.Parameters.AddWithValue("@Sobrenome", funcionario.Sobrenome);


                conn.Open();

                cmmd.ExecuteNonQuery();

            }
        }

        public void UpdateIdUrl(int id, FuncionarioDomain funcionario)
        {
            using(SqlConnection conn = new SqlConnection(connection))
            {
                string queryUpdate = "UPDATE Funcionarios SET Nome = @Nome, Sobrenome = @Sobrenome WHERE IdFuncionario = @ID ";

                SqlCommand cmmd = new SqlCommand(queryUpdate, conn);

                cmmd.Parameters.AddWithValue("@Nome", funcionario.Nome);

                cmmd.Parameters.AddWithValue("@Sobrenome", funcionario.Sobrenome);

                cmmd.Parameters.AddWithValue("@ID", id);

                conn.Open();

                cmmd.ExecuteNonQuery();
            }

        }

        public void Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(connection))
            {
                string queryDelete = "DELETE FROM Funcionarios WHERE IdFuncionario= @ID";

                using (SqlCommand cmmd = new SqlCommand(queryDelete, conn))
                {

                    cmmd.Parameters.AddWithValue("@ID", id);

                    conn.Open();

                    cmmd.ExecuteNonQuery();
                }
            }
        }
    }
}


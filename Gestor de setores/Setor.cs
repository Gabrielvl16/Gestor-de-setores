using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace Gestor_de_setores
{
    public class Setor
    {
        private static string connectionString = "server=localhost;user=root;database=empresa;password=";

        public int ID { get; set; }
        public string Nome { get; set; }

        public static void InserirSetor(Setor setor)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string sql = "INSERT INTO setores (nome) VALUES (@nome)";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@nome", setor.Nome);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public static void AtualizarSetor(Setor setor)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string sql = "UPDATE setores SET nome=@nome WHERE id=@id";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", setor.ID);
                cmd.Parameters.AddWithValue("@nome", setor.Nome);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public static void ExcluirSetor(int id)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string sql = "DELETE FROM setores WHERE id=@id";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", id);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public static List<Setor> ListarTodosSetores()
        {
            List<Setor> setores = new List<Setor>();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string sql = "SELECT * FROM setores";
                MySqlCommand cmd = new MySqlCommand(sql, conn);

                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    setores.Add(new Setor
                    {
                        ID = Convert.ToInt32(reader["id"]),
                        Nome = reader["nome"].ToString()
                    });
                }
            }
            return setores;
        }

        public static List<Setor> ListarSetorPorNome(string nome)
        {
            List<Setor> setores = new List<Setor>();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string sql = "SELECT * FROM setores WHERE nome LIKE @nome";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@nome", "%" + nome + "%");

                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    setores.Add(new Setor
                    {
                        ID = Convert.ToInt32(reader["id"]),
                        Nome = reader["nome"].ToString()
                    });
                }
            }
            return setores;
        }
    }
}

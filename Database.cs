using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text.Json;


namespace VogelLibrary
{
    /// <summary>
    /// Classe com funções para Insert, Update e Select de uma tabela específica no banco.
    /// </summary>

    public class Database
    {
        string _connectionString;
        /// <summary>
        /// Construtor.
        /// </summary>
        public Database() 
        {
            _connectionString = Config.GetConnectionString();
        }

        private void ExecuteVoid(string sql)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_connectionString);
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private string ExecuteReader(string sql)
        {
            List<Dictionary<string, dynamic>> list = new List<Dictionary<string, dynamic>>();
            try
            {
                SqlConnection conn = new SqlConnection(_connectionString);
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Dictionary<string, object> obj = new Dictionary<string, object>();
                    for (int i = 0; i < rdr.FieldCount; i++)
                    {
                        obj[rdr.GetName(i)] = rdr.GetValue(i);
                    }                   
                    list.Add(obj);
                }

                conn.Close();

                string jsonList = JsonSerializer.Serialize(list);

                return jsonList;
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// Inserção de dados em uma tabela específica no banco de dados.
        /// </summary>
        /// <param name="table">Nome da tabela onde os dados serão inseridos. Passar só o nome, sem os [].</param>
        /// <param name="columns">Nomes das colunas que serão usadas na inserção. Passar só os nomes e separar por virgula. Não passar os ().</param>
        /// <param name="values">Valores a serem inseridos nas colunas correspondentes. Passar só os valores separados por virgula. Não passar VALUES().</param>
        public void Insert(string table, string columns, string values)
        {
            try
            {
                string sql = $"INSERT INTO [{table}] ({columns}) VALUES({values})";
                ExecuteVoid(sql);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Atualizar dados em uma tabela específica no banco de dados.
        /// </summary>
        /// <param name="table">Nome da tabela que será atualizada. Passar só o nome, sem os [].</param>
        /// <param name="updateParams">Parametros de atualização. Ex: coluna1=valor1, [coluna 2]=valor2.</param>
        /// <param name="whereArgs">Passar os parametros do Where. NÃO PASSAR O WHERE.</param>
        public void Update(string table, string updateParams, string whereArgs)
        {
            try
            {
                whereArgs = whereArgs.Length > 0 ? "WHERE " + whereArgs : "";
                string sql = $"UPDATE [{table}] SET {updateParams} {whereArgs}";
                ExecuteVoid(sql);
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// Buscar dados em uma tabela específica no banco de dados.
        /// </summary>
        /// <param name="table">Nome da tabela. Passar só o nome, sem os [].</param>
        /// <param name="fields">Nomes dos campos de retorno. Passar só os nomes e separar por virgula.</param>
        /// <param name="whereArgs">Passar os parametros do Where. NÃO PASSAR O TEXT "WHERE".</param>
        public string Find(string table, string fields, string whereArgs)
        {
            whereArgs = whereArgs.Length > 0 ? "WHERE " + whereArgs : "";
            string sql = $"SELECT {fields} FROM {table} {whereArgs}";
            string list = ExecuteReader(sql);
            return list;
        }

    }
}

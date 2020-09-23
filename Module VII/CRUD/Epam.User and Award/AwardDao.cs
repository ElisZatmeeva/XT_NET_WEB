using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.User_and_Award.DAL.Interfaces;
using Epam.Users_and_Award.Entities;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace Epam.User_and_Award.DAL
{
    public class AwardDao : IAwardDao
    {
        private string _connectionString = "Data Source=LAPTOP-NUM19DBK\\SQLEXPRESS;Initial Catalog=Users_and_Awards;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public void Add(string title)
        {

            string sqlExpression = "AwardsAdd";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                
                command.CommandType = System.Data.CommandType.StoredProcedure;
                
                SqlParameter titleParam = new SqlParameter
                {
                    ParameterName = "@Title",
                    Value = title,
                    SqlDbType = SqlDbType.NVarChar,
                };
                
                command.Parameters.Add(titleParam);

                var result = command.ExecuteScalar();

                Console.WriteLine("Id добавленного объекта: {0}", result);
            }
        }


        public Award GetAwardById(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "AwardGetById";
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@Id",
                    Value = id,
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Input
                });

                connection.Open();

                var reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return new Award()
                    {
                        Id = (int)reader["AwardsId"],
                        Title = reader["Tutle"] as string
                    };
                }

                throw new InvalidOperationException("Cannot find User with ID = " + id);
            }
        }



        public IEnumerable<Award> GetAll()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "AwardsGetAll";
                command.CommandType = System.Data.CommandType.StoredProcedure;

                connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    yield return new Award()
                    {
                        Id = (int)reader["AwardsId"],
                        Title = reader["Tutle"] as string
                    };
                }
            }
        }

        public void Update(int id, string title)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "AwardUpdate";
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@Id",
                    Value = id,
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Input

                });

                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@Title",
                    Value = title,
                    SqlDbType = SqlDbType.NVarChar,
                    Direction = ParameterDirection.Input

                });

                connection.Open();
                command.ExecuteScalar();

            }
        }

        public void DeleteById(int id)
        {

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    var command = connection.CreateCommand();
                    command.CommandText = "AwardDeleteById";
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter
                    {
                        ParameterName = "@Id",
                        Value = id,
                        SqlDbType = SqlDbType.Int,
                        Direction = ParameterDirection.Input
                    });

                    connection.Open();

                    var result = command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine("{0} Введите верное значение id", e);
                }
            }
        }

    }
}

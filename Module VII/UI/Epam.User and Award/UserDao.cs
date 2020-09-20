using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Users_and_Award.Entities;
using System.IO;
using Newtonsoft.Json;
using Epam.User_and_Award.DAL.Interfaces;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;


namespace Epam.User_and_Award.DAL
{
    public class UserDao : IUserDao
    {
        private string _connectionString = "Data Source=LAPTOP-NUM19DBK\\SQLEXPRESS;Initial Catalog=Users_and_Awards;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        // добавление пользователя
        public void Add(string name, int age, DateTime DateOfBirth)
        {
            // название процедуры
            string sqlExpression = "UsersAdd5";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                // указываем, что команда представляет хранимую процедуру
                command.CommandType = System.Data.CommandType.StoredProcedure;
                // параметр для ввода имени
                SqlParameter nameParam = new SqlParameter
                {
                    ParameterName = "@Name",
                    Value = name,
                    SqlDbType = SqlDbType.NVarChar,
                };
                // добавляем параметр
                command.Parameters.Add(nameParam);

                // параметр для ввода даты
                SqlParameter dateOfBirth = new SqlParameter
                {
                    ParameterName = "@DateOfBirth",
                    Value = DateOfBirth,
                    SqlDbType = SqlDbType.DateTime
                };
                // добавляем параметр
                command.Parameters.Add(dateOfBirth);

                // параметр для ввода возраста
                SqlParameter ageParam = new SqlParameter
                {
                    ParameterName = "@Age",
                    Value = age,
                    SqlDbType = SqlDbType.Int,
                };
                command.Parameters.Add(ageParam);

                var result = command.ExecuteScalar();

                Console.WriteLine("Id добавленного объекта: {0}", result);
            }
        }   

        public User GetUserById(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "UserGetById";
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
                    return new User()
                    {
                        Id = (int)reader["Id"],
                        Name = reader["Name"] as string,
                        DateOfBirth = (DateTime)reader["DateOfBirth"],
                        Age = (int)reader["Age"]
                    };
                }

                throw new InvalidOperationException("Cannot find User with ID = " + id);
            }
        }

        public void DeleteById(int id)
        {

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    var command = connection.CreateCommand();
                    command.CommandText = "UserDeleteById";
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

        public IEnumerable<User> GetAll()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "UsersGetAll";
                command.CommandType = System.Data.CommandType.StoredProcedure;

                connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    yield return new User()
                    {
                        Id = (int)reader["Id"],
                        Name = reader["Name"] as string,
                        DateOfBirth = (DateTime)reader["DateOfBirth"],
                        Age = (int)reader["Age"]
                    };
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using Business.Domain_Layer;
using Business.Domain_Layer.Entities;
using MySql.Data.MySqlClient;

namespace Business.Persistence_Layer
{
    internal class CafeMapper
    {
        private readonly string _connectionString;

        internal CafeMapper(string connectionString)
        {
            _connectionString = connectionString;
        }

        internal List<Cafe> getCafesFromDb()
        {
            var cafes = new List<Cafe>();

            var connection = new MySqlConnection(_connectionString);
            var command = new MySqlCommand("SELECT * FROM cafe", connection);

            connection.Open();
            var dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                var _cafe = new Cafe(
                    Convert.ToInt32(dataReader["id"]),
                    Convert.ToString(dataReader["omschrijving"])
                );


                Console.WriteLine($"Gathering all stocks from cafeid: {_cafe.Id}");

                command = new MySqlCommand("SELECT * FROM stock WHERE cafe_id = @cafeid", connection);
                command.Parameters.AddWithValue("cafeid", _cafe.Id);
                var stockDataReader = command.ExecuteReader();
                while (stockDataReader.Read())
                    _cafe.Stocks.Add(new Stock(Convert.ToInt32(stockDataReader["id"]), Convert.ToString(stockDataReader["stockdescription"])));

                Console.WriteLine($"Cafe {_cafe.Description} has {_cafe.Stocks.Count} diffrent stocks");

                cafes.Add(_cafe);
            }

            connection.Close();
            return cafes;
        }

        internal void AddCafeToDb(Cafe cafe)
        {
            var connection = new MySqlConnection(_connectionString);
            var command = new MySqlCommand(
                "INSERT INTO cafe (id, omschrijving) " + 
                "VALUES (@id, @description)", connection);
            command.Parameters.AddWithValue("id", cafe.Id);
            command.Parameters.AddWithValue("description", cafe.Description);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        internal void UpdateCafeInDb(Cafe cafe)
        {
            var connection = new MySqlConnection(_connectionString);
            var command = new MySqlCommand(
                "UPDATE cafe SET description = @description "+
                "WHERE id = @id", connection);
            command.Parameters.AddWithValue("id", cafe.Id);
            command.Parameters.AddWithValue("description", cafe.Description);
            
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        internal void DeleteCafeFromDb(Cafe cafe)
        {
            var connection = new MySqlConnection(_connectionString);
            var command = new MySqlCommand(
                "DELETE FROM cafe " +
                "WHERE id=@id", connection);
            command.Parameters.AddWithValue("id", cafe.Id);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}
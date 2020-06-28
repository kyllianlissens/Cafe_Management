using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Domain_Layer;
using MySql.Data.MySqlClient;

namespace Business.Persistence_Layer
{
    internal class ProductMapper
    {

        private readonly string _connectionString;

        internal ProductMapper(string connectionString)
        {
            _connectionString = connectionString;
        }

        internal List<Product> GetProductsFromDb()
        {
            var products = new List<Product>();

            var connection = new MySqlConnection(_connectionString);
            var command =
                new MySqlCommand("SELECT * FROM product WHERE package_idpackage IS NULL AND sale_idsale IS NULL",
                    connection); //TODO Update for purchase_idsale FK

            connection.Open();
            var dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                var _product = new Product(
                    Convert.ToInt32(dataReader["id"]),
                    Convert.ToDouble(dataReader["saleprice"]),
                    Convert.ToString(dataReader["description"]),
                    Convert.ToDouble(dataReader["purchaseprice"])
                );
                Console.WriteLine($"Adding product: {_product.Id}: {_product.Description}");
                products.Add(_product);
            }
            return products;
        }

        internal void AddProductToDb(Product product)
        {
            var connection = new MySqlConnection(_connectionString);
            var command = new MySqlCommand(
                "INSERT INTO cafe (id, stock_stock_id, description, purchaseprice, saleprice) " +
                "VALUES (@id, @stockid, @description, @purchaseprice, @saleprice)", connection);
            command.Parameters.AddWithValue("id", product.Id);
            command.Parameters.AddWithValue("description", product.Description);
            command.Parameters.AddWithValue("stockid", product.Stock.)

        }


        /*
         *
         *  Random comment :thinking:
         *  
         *
         *
         */
    }
}

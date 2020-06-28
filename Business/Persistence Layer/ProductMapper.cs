using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Domain_Layer;
using Business.Domain_Layer.Repositories;
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
                    Convert.ToDouble(dataReader["purchaseprice"]),
                    StockRepository.Items.Find(x=> x.Id == Convert.ToInt32(dataReader["stock_stock_id"]))
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
                "INSERT INTO product (id, stock_stock_id, description, purchaseprice, saleprice) " +
                "VALUES (@id, @stockid, @description, @purchaseprice, @saleprice)", connection);
            command.Parameters.AddWithValue("id", product.Id);
            command.Parameters.AddWithValue("description", product.Description);
            command.Parameters.AddWithValue("stockid", product.Stock.Id);
            command.Parameters.AddWithValue("purchaseprice", product.PurchasePrice);
            command.Parameters.AddWithValue("saleprice", product.SalePrice);


            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        internal void UpdateProductInDb(Product product)
        {
            var connection = new MySqlConnection(_connectionString);
            var command = new MySqlCommand(
                "UPDATE cafe SET description = @description, purchaseprice = @purchaseprice, saleprice = @saleprice " +
                "WHERE id = @id", connection);
            command.Parameters.AddWithValue("id", product.Id);
            command.Parameters.AddWithValue("description", product.Description);
            command.Parameters.AddWithValue("purchaseprice", product.PurchasePrice);
            command.Parameters.AddWithValue("saleprice", product.SalePrice);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        internal void DeleteProductFromDb(Product product)
        {
            var connection = new MySqlConnection(_connectionString);
            var command = new MySqlCommand(
                "DELETE FROM product " +
                "WHERE id=@id", connection);
            command.Parameters.AddWithValue("id", product.Id);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}

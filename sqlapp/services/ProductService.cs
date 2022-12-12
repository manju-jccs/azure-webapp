using sqlapp.models;
using System.Data.SqlClient;

namespace sqlapp.services
{
    public class ProductService
    {
        private static String dbSource = "mnsnp.database.windows.net";
        private static string dbUser = "manjujccs";
        private static string dbPassword = "Jayama#4";
        private static string dbName = "manjujccs";

        private SqlConnection getConncetion()
        {
            var builder =new SqlConnectionStringBuilder();
            builder.DataSource = dbSource;
            builder.UserID = dbUser;
            builder.Password = dbPassword;
            builder.InitialCatalog = dbName;
            return new SqlConnection(builder.ConnectionString);

        }

        public List<Product> getProducts()
        {
            SqlConnection connection = getConncetion();
            List<Product> products = new List<Product>();
            string query = "select * from products";
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while(reader.Read())
                {
                    Product product = new Product()
                    {
                        productId = reader.GetInt32(0),
                        productName = reader.GetString(1),
                        quantity = reader.GetInt32(2)

                    };
                    products.Add(product);
                }
            }
            connection.Close();

            return products;
        }



    }
}

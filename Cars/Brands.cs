using Azure.Core;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using System.Data.SqlClient;
using carswebapp.Manufacturers;

namespace carswebapp.Cars
{
    public class Brands
    {
        //  private static string db_database = "";
        //  private static string db_password = "";
        // private static string db_source = "******.database.windows.net";
        //  private static string db_user = "";
        private SqlConnection GetConnection()
        {
            TokenCredential tokenCredential = new DefaultAzureCredential();

            string KeyVaultUrl = "https://kvcars2023.vault.azure.net/";
            string secretName = "dbconnectstringcars";

            SecretClient secretClient = new SecretClient(new Uri(KeyVaultUrl), tokenCredential);

            var secret = secretClient.GetSecret(secretName);

            string connectionString = secret.Value.Value;

            return new SqlConnection(connectionString);

            //var _builder = new SqlConnectionStringBuilder();
            //_builder.DataSource = db_source;
            // _builder.UserID = db_user;
            // _builder.Password = db_password;
            // _builder.InitialCatalog = db_database;
            //  return new SqlConnection(_builder.ConnectionString);
        }
        //public List<Offerings> GetModels(string Manufacturer, string Model, string type, int Price in USD, int DiscountPercent)
        public List<Offerings> GetModels()
        {
            List<Offerings> _model_lst = new List<Offerings>();

            SqlConnection _conn = GetConnection();

            string _statement = "SELECT Manufacturer,Model,Type,Price from Models";

            _conn.Open();

            SqlCommand _sqlcommand = new SqlCommand(_statement, _conn);

            using (SqlDataReader _reader = _sqlcommand.ExecuteReader())

            {
                while (_reader.Read())
                {
                    Offerings course = new Offerings()
                    {
                        Manufacturer = _reader.GetString(0),
                        Model = _reader.GetString(1),
                        Type = _reader.GetString(2),
                        Price = _reader.GetString(3),

                    };
                    _model_lst.Add(course);
                }
                _conn.Close();

                return _model_lst;
            }
        }
    }
}
            //private List<courses> _courses_lst;

            //private string CourseID;
            //private string CourseName;
            //private int Price;
            //private int Discountpercentage;


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Globalization;

namespace BankApp.Model
{
    public enum ModelFacadeStatus
    {
        OK,
        Failed,
        InternalError
    }
    public class ModelFacade
    {
        private static ModelFacade _instance;
        private IdentifiedClient _identifiedClient;
        private const string _areUsersQuery = "SELECT COUNT(*) FROM Client";
        private const string _loginQuery = "SELECT Id FROM Client WHERE UserName=@UserName AND Password=@Password";
        private const string _codesQuery = "SELECT Id FROM Client";
        private const string _clientByCodeQuery = "SELECT Id, FirstName, LastName, UserName, Country, Region, City, Address FROM Client WHERE Id=@QueryId";
        private const string _updateClientQuery =
            "UPDATE Client SET " +
            "FirstName = @FirstName, LastName = @LastName, Country = @Country, Region=@Region, City=@City, Address=@Address " +
            "WHERE " +
            "Id=@Id AND " +
            "UserName = @UserName AND " +
            "FirstName=@OriginalFirstName AND " +
            "LastName=@OriginalLastName AND " +
            "(Country=@OriginalCountry OR(Country IS NULL AND @OriginalCountry IS NULL)) AND " +
            "(Region=@OriginalRegion OR(Region IS NULL AND @OriginalRegion IS NULL)) AND " +
            "(City=@OriginalCity OR(City IS NULL AND @OriginalCity IS NULL)) AND " +
            "(Address=@OriginalAddress OR(Address IS NULL AND @OriginalAddress IS NULL))";
        private const string _deleteClientQuery = "DELETE FROM Client WHERE " +
            "Id=@Id AND " +
            "UserName = @UserName AND " +
            "FirstName = @OriginalFirstName AND " +
            "LastName = @OriginalLastName AND " +
            "Country = @OriginalCountry AND " +
            "Region = @OriginalRegion AND " +
            "City = @OriginalCity AND " +
            "Address = @OriginalAddress";
        private const string _clientAccountsQuery = "SELECT Id, ClientId, Number, Description FROM Account WHERE ClientId=@ClientId";

        private const string _insertClientQuery="INSERT INTO Client(UserName, Password, FirstName, LastName, Country, Region, City, Address) OUTPUT INSERTED.Id VALUES(@UserName, @Password,@FirstName,@LastName,@Country,@Region,@City,@Address)";

        public static ModelFacade Singleton
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ModelFacade();
                }
                return _instance;
            }
        }

        public IdentifiedClient IdentifiedClient { get => _identifiedClient; }

        public ModelFacadeStatus AreUsers()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString()))
            {
                SqlCommand command = new SqlCommand(_areUsersQuery, connection);
                try
                {
                    connection.Open();
                    int users = (int)command.ExecuteScalar();
                    return (users>0)?ModelFacadeStatus.OK:ModelFacadeStatus.Failed;
                }
                catch (Exception)
                {
                    return ModelFacadeStatus.InternalError;
                }
            }
        }

        public int InsertClient(Client client)
        {
            Guard();
            using (SqlConnection connection = new SqlConnection(ConnectionString()))
            {
                SqlCommand command = new SqlCommand(_insertClientQuery, connection);
                command.Parameters.AddWithValue("@UserName", client.UserName);
                command.Parameters.AddWithValue("@Password", client.Password);
                command.Parameters.AddWithValue("@FirstName", client.FirstName);
                command.Parameters.AddWithValue("@LastName", client.LastName);
                command.Parameters.AddWithValue("@Country", client.Country);
                command.Parameters.AddWithValue("@Region", client.Region);
                command.Parameters.AddWithValue("@City", client.City);
                command.Parameters.AddWithValue("@Address", client.Address);
                try
                {
                    connection.Open();
                    int id = (int)command.ExecuteScalar();
                    return id;
                }
                catch (Exception)
                {
                    return -1;
                }
            }
        }
        public ModelFacadeStatus UpdateClient(Client client)
        {
            Guard();
            using (SqlConnection connection = new SqlConnection(ConnectionString()))
            {
                SqlCommand command = new SqlCommand(_updateClientQuery, connection);
                command.Parameters.AddWithValue(@"Id", client.Id);
                command.Parameters.AddWithValue(@"UserName", client.UserName);
                command.Parameters.AddWithValue("@FirstName", client.FirstName);
                command.Parameters.AddWithValue("@OriginalFirstName", client.OriginalFirstName);
                command.Parameters.AddWithValue("@LastName", client.LastName);
                command.Parameters.AddWithValue("@OriginalLastName", client.OriginalLastName);
                command.Parameters.AddWithValue("@Country", (object)client.Country ?? DBNull.Value);
                command.Parameters.AddWithValue("@OriginalCountry", (object)client.OriginalCountry ?? DBNull.Value);
                command.Parameters.AddWithValue("@Region", (object)client.Region ?? DBNull.Value);
                command.Parameters.AddWithValue("@OriginalRegion", (object)client.OriginalRegion ?? DBNull.Value);
                command.Parameters.AddWithValue("@City", (object)client.City ?? DBNull.Value);
                command.Parameters.AddWithValue("@OriginalCity", (object)client.OriginalCity ?? DBNull.Value);
                command.Parameters.AddWithValue("@Address", (object)client.Address ?? DBNull.Value);
                command.Parameters.AddWithValue("@OriginalAddress", (object)client.OriginalAddress ?? DBNull.Value);
                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return (rowsAffected > 0)?ModelFacadeStatus.OK:ModelFacadeStatus.Failed;
                }
                catch (Exception)
                {
                    return ModelFacadeStatus.InternalError;
                }
            }
        }
        public ModelFacadeStatus DeleteClient(Client client)
        {
            Guard();
            using (SqlConnection connection = new SqlConnection(ConnectionString()))
            {
                SqlCommand command = new SqlCommand(_deleteClientQuery, connection);
                command.Parameters.AddWithValue("@Id", client.Id);
                command.Parameters.AddWithValue("@UserName", client.UserName);
                command.Parameters.AddWithValue("@OriginalFirstName", client.OriginalFirstName);
                command.Parameters.AddWithValue("@OriginalLastName", client.OriginalLastName);
                command.Parameters.AddWithValue("@OriginalCountry", client.OriginalCountry);
                command.Parameters.AddWithValue("@OriginalRegion", client.OriginalRegion);
                command.Parameters.AddWithValue("@OriginalCity", client.OriginalCity);
                command.Parameters.AddWithValue("@OriginalAddress", client.OriginalAddress);
                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return (rowsAffected > 0)?ModelFacadeStatus.OK:ModelFacadeStatus.Failed;
                }
                catch (Exception)
                {
                    return ModelFacadeStatus.InternalError;
                }
            }
        }

        public List<Account> AccountsForClient(Client client)
        {
            Guard();
            using (SqlConnection connection = new SqlConnection(ConnectionString()))
            {
                SqlCommand command = new SqlCommand(_clientAccountsQuery, connection);
                command.Parameters.AddWithValue("@ClientId", client.Id);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                try
                {
                    List<Account> ret = new List<Account>();
                    while (reader.Read())
                    {
                        ret.Add(new Account(
                            (int)reader["Id"],
                            (int)reader["ClientId"],
                            reader["Number"] as string,
                            reader["Description"] as string
                            ));
                    }
                    return ret;
                }
                catch (Exception)
                {
                    return null;
                }
                finally
                {
                    reader.Close();
                }
            }
        }
        public Client ClientByCode(int code)
        {
            Guard();
            using (SqlConnection connection = new SqlConnection(ConnectionString()))
            {
                SqlCommand command = new SqlCommand(_clientByCodeQuery, connection);
                command.Parameters.AddWithValue("@QueryId", code);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                try
                {
                    if (reader.Read())
                    {
                        return new Client(
                            (int)reader["Id"],
                            reader["FirstName"] as string,
                            reader["LastName"] as string,
                            reader["UserName"] as string,
                            reader["Country"] as string,
                            reader["Region"] as string,
                            reader["City"] as string,
                            reader["Address"] as string
                            );
                    }
                    else
                    { 
                        return new Client(true);
                    }
                }
                catch (Exception)
                {
                    return null;
                }
                finally
                {
                    reader.Close();
                }
            }
        }
        public List<int> ClientCodes()
        {
            Guard();
            using (SqlConnection connection = new SqlConnection(ConnectionString()))
            {
                SqlCommand command = new SqlCommand(_codesQuery, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                List<int> ret = new List<int>();
                try
                {
                    while (reader.Read())
                    {
                        ret.Add((int)reader["Id"]);
                    }
                    return ret;
                }
                catch (Exception)
                {
                    return null;
                }
                finally
                {
                    reader.Close();
                }
            }
        }
        private void Guard()
        {
            if (!LoggedIn())
            {
                throw new InvalidOperationException("You must be logged in to use this operation");
            }
        }
        public byte[] PreparePassword(String password)
        {
            byte[] hashed;
            using (SHA512 hasher = new SHA512Managed())
            {
                hashed = hasher.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
            return hashed;
        }
        public ModelFacadeStatus Login(String userName, String password)
        {
            if (LoggedIn())
            {
                LogOut();
            }
            byte[] hashed = PreparePassword(password);
            using (SqlConnection connection = new SqlConnection(ConnectionString()))
            {
                SqlCommand command = new SqlCommand(_loginQuery, connection);
                command.Parameters.AddWithValue("@UserName", userName);
                command.Parameters.AddWithValue("@Password", hashed);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                try
                {
                    if (reader.Read())
                    {
                       _identifiedClient=new IdentifiedClient((int)reader["Id"],userName);
                        return ModelFacadeStatus.OK;
                    }
                    else
                    {
                        return ModelFacadeStatus.Failed;
                    }
                }
                catch (Exception)
                {
                    return ModelFacadeStatus.InternalError;
                }
                finally
                {
                    reader.Close();
                }
            }
        }
        public bool LoggedIn()
        {
            return _identifiedClient != null;
        }
        public void LogOut()
        {
            _identifiedClient = null;
        }
        private string ConnectionString()
        {
            return Properties.Settings.Default.BankAppDBConnectionString;
        }
        public IDictionary<String, String> ValidCountries()
        {
            SortedDictionary<String, String> ret = new SortedDictionary<String, String>();
            CultureInfo[] cultures = CultureInfo.GetCultures(CultureTypes.AllCultures & ~CultureTypes.NeutralCultures);

            foreach (CultureInfo culture in cultures)
            {
                if (!culture.IsNeutralCulture && culture.LCID!=127)
                {
                    RegionInfo region = new RegionInfo(culture.LCID);
                    ret[region.EnglishName] = region.TwoLetterISORegionName;
                }
            }
            return ret;
        }
    }
}

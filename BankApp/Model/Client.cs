using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Model
{
    public class Client
    {
        private int _id;
        private string _userName;
        private byte[] _password;
        private string _firstName;
        private string _originalFirstName;
        private string _lastName;
        private string _originalLastName;
        private string _country;
        private string _originalCountry;
        private string _region;
        private string _originalRegion;
        private string _city;
        private string _originalCity;
        private string _address;
        private string _originalAddress;
        private bool _empty;

        public Client()
        {

        }
        public Client(bool empty)
        {
            _empty = empty;
        }
        public Client(int id, string firstName, string lastName, string userName, string country, string region, string city, string address)
        {
            _id = id;
            _firstName = firstName;
            _originalFirstName = firstName;
            _lastName = lastName;
            _originalLastName = lastName;
            _userName = userName;
            _country = country;
            _originalCountry = country;
            _region = region;
            _originalRegion = region;
            _city = city;
            _originalCity = city;
            _address = address;
            _originalAddress = address;
        }
        public int Id { get => _id; }
        public string UserName { get => _userName; set => _userName = value;  }
        public string FirstName { get => _firstName; set => _firstName = value; }
        public string OriginalFirstName { get => _originalFirstName; }
        public string LastName { get => _lastName; set => _lastName = value; }
        public string OriginalLastName { get => _originalLastName; }
        public string Country { get => _country; set => _country = value; }
        public string OriginalCountry { get => _originalCountry; }
        public string Region { get => _region; set => _region = value; }
        public string OriginalRegion { get => _originalRegion; }
        public string City { get => _city; set => _city = value; }
        public string OriginalCity { get => _originalCity; }
        public string Address { get => _address; set => _address = value; }
        public string OriginalAddress { get => _originalAddress; }
        public byte[] Password { get => _password; set => _password = value; }
        public bool Empty { get => _empty; }
    }
}

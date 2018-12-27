using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Model
{
    public class Account
    {
        private int _id;
        private int _clientId;
        private string _number;
        private string _originalNumber;
        private string _description;
        private string _originalDescription;

        public Account(int id, int clientId, string number, string description)
        {
            _id = id;
            _clientId = clientId;
            _number = number;
            _originalNumber = number;
            _description = description;
            _originalDescription = description;
        }

        public int Id { get => _id; }
        public int ClientId { get => _clientId;  }
        public string Number { get => _number; set => _number = value; }
        public string OriginalNumber { get => _originalNumber; }
        public string Description { get => _description; set => _description = value; }
        public string OriginalDescription { get => _originalDescription;}
    }
}

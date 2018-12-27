using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Model
{
    public class IdentifiedClient
    {
        private int _id;
        private string _userName;

        public IdentifiedClient(int id, String userName)
        {
            _id = id;
            _userName = userName;
        }
        
        public int Id { get => _id; }
        public string UserName { get => _userName; }
    }
}

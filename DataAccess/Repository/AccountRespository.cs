using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class AccountRespository : IAccountRespository
    {
        public void Add(Account account)
        {
            throw new NotImplementedException();
        }

        public void Delete(Account account)
        {
            throw new NotImplementedException();
        }

   

        public Account FindByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Account FindByEmailAndPassword(string email, string password)
        {
            return AccountDAO.Instance.FindOne(acc => acc.Username == email && acc.Password == password);
        }

        public Account FindById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Account> List()
        {
            throw new NotImplementedException();
        }

        public void Update(Account account)
        {
            throw new NotImplementedException();
        }
    }
}

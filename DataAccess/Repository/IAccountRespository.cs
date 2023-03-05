using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IAccountRespository
    {
        IEnumerable<Account> List();
        void Add(Account account);
        void Update(Account account);
        void Delete(Account account);
        Account FindById(int id);
        Account FindByEmail(string email);
        Account FindByEmailAndPassword(string email, string password);
     
    }
}

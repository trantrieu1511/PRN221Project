using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class AccountDAO
    {
        private static AccountDAO instance = null;
        private static readonly object instanceLock = new object();
        public AccountDAO() { }
        public static AccountDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new AccountDAO();
                    }
                    return instance;
                }

            }
        }
        public IEnumerable<Account> List()
        {
            List<Account> acc = new List<Account>();
            try
            {
                using (var qlns = new PRN221_QLNSContext())
                {
                    acc = qlns.Accounts.ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return acc;
        }
        public IEnumerable<Account> FindAll(Expression<Func<Account, bool>> pre)
        {
            List<Account> acc = new List<Account>();
            try
            {
                using (var qlns = new PRN221_QLNSContext())
                {
                    acc = qlns.Accounts.Where(pre).ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return acc;
        }
        public Account FindOne(Expression<Func<Account, bool>> pre)
        {
            Account acc = null;
            try
            {
                using (var qlns = new PRN221_QLNSContext())
                {
                    acc = qlns.Accounts.SingleOrDefault(pre);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return acc;
        }
        public void AddNew(Account acc)
        {
            try
            {
                Account p = FindOne(item => item.ProfileId.Equals(acc.ProfileId));
                if (p == null)
                {
                    using (var qlnv = new PRN221_QLNSContext())
                    {
                        qlnv.Accounts.Add(acc);
                        qlnv.SaveChanges();
                    }

                }
                else
                {
                    throw new Exception("The Account is already exist");
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }
        public void Update(Account acc)
        {
            try
            {
                Account p = FindOne(item => item.ProfileId.Equals(acc.ProfileId));
                if (p != null)
                {
                    using (var qlnv = new PRN221_QLNSContext())
                    {
                        qlnv.Entry<Account>(acc).State = EntityState.Modified;
                        qlnv.SaveChanges();
                    }
                }
                else
                {
                    throw new Exception("The Account does not exist");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public void Delete(Account member)
        {
            try
            {
                Account p = FindOne(item => item.ProfileId == member.ProfileId);

                if (p != null)
                {
                    using (var qlnv = new PRN221_QLNSContext())
                    {
                        qlnv.Accounts.Remove(member);
                        qlnv.SaveChanges();
                    }
                }
                else
                {
                    throw new Exception("The Account does not exist");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }

}


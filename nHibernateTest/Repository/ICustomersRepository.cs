using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using nHibernateTest.Entity;
using nHibernateTest.Infra;
namespace nHibernateTest.Repository
{
    public interface ICustomersRepository : IRepository<Customers, string>
    {
    }
}

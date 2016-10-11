using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using nHibernateTest.Entity;
using nHibernateTest.Infra;

namespace nHibernateTest.Repository
{
    public class CustomersRepository : Repository<Customers, string>, ICustomersRepository
    {
        public CustomersRepository(IUnitOfWork uow):base(uow)
        {

        }

    }
}

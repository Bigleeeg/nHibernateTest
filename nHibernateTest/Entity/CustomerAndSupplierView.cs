using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nHibernateTest.Entity
{
    public class CustomerAndSupplierView
    {
        public virtual string City { get;  set; }
        public virtual string CompanyName { get;  set; }
        public virtual string ContactName { get;  set; }
        public virtual string Relationship { get;  set; }
    }
}

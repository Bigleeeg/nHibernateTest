using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nHibernateTest.Entity
{
    public class CustomerDemographics
    {
        public CustomerDemographics()
        {
            Customers = new HashSet<Customers>();
        }

        public virtual string CustomerDesc { get; set; }
        public virtual string CustomerTypeID { get; set; }

        public virtual ISet<Customers> Customers { get; set; }
    }
}

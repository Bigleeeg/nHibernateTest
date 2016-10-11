using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using nHibernateTest.Infra;

namespace nHibernateTest.Entity
{
    public class Customers:IAggregateRoot
    {
        public Customers()
        {
            Orders = new HashSet<Orders>();
            CustomerDemographics = new HashSet<CustomerDemographics>();
        }

        public virtual string CustomerID { get; set; }
        public virtual string CompanyName { get; set; }
        public virtual string ContactName { get; set; }
        public virtual string ContactTitle { get; set; }
        public virtual string Address { get; set; }
        public virtual string City { get; set; }
        public virtual string Region { get; set; }
        public virtual string PostalCode { get; set; }
        public virtual string Country { get; set; }
        public virtual string Phone { get; set; }
        public virtual string Fax { get; set; }

        public virtual ISet<Orders> Orders { get; set; }

        public virtual ISet<CustomerDemographics> CustomerDemographics { get; set; } 
    }
}

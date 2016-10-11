using nHibernateTest.Entity;
using nHibernateWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace nHibernateWeb.BL
{
    public class CustomersBL
    {

        public static CustomerModel TransferModel(Customers item)
        {
            CustomerModel cm = null;
            if (item != null)
            {
                cm = new CustomerModel()
                {
                    CustomerID = item.CustomerID,
                    CompanyName = item.CompanyName,
                    ContactName = item.ContactName,
                    ContactTitle = item.ContactTitle,
                    Address = item.Address,
                    City = item.City,
                    Region = item.Region,
                    PostalCode = item.PostalCode,
                    Country = item.Country,
                    Phone = item.Phone,
                    Fax = item.Fax
                };
            }
            return cm;
        }

        public static List<CustomerModel> TransferModel(List<Customers> listItem)
        {
            List<CustomerModel> cmList = new List<CustomerModel>();
            if (listItem != null && listItem.Count > 0)
            {
                foreach (Customers item in listItem)
                {
                    CustomerModel cm = TransferModel(item);
                    cmList.Add(cm); 
                }
            } 
            return cmList;
        }
    }
}
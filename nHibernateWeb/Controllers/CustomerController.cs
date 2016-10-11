using NHibernate;
using nHibernateTest.Entity;
using nHibernateWeb.BL;
using nHibernateWeb.DAL;
using nHibernateWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace nHibernateWeb.Controllers
{
    public class CustomerController : Controller
    {

        // GET: Customer
        public ActionResult ListView()
        {
            using (var session = CustomersDAL.sessionFactory.OpenSession())
            {
                ICriteria criteria = session.CreateCriteria(typeof(Customers));
                var customersList = criteria.List<Customers>();
                List<CustomerModel> cmList = CustomersBL.TransferModel(customersList.ToList());
                ViewData["cusList"] = cmList;
                return View();
            }
        }

        public ActionResult EditView()
        {
            string customerId = Request.QueryString["customerId"] == null ? string.Empty : Request.QueryString["customerId"].ToString();
            if (!string.IsNullOrEmpty(customerId))
            {
                using (var session = CustomersDAL.sessionFactory.OpenSession())
                {
                    //ICriteria criteria = session.CreateCriteria(typeof(Customers));
                    IList<Customers> list = session.QueryOver<Customers>().Where(o => o.CustomerID == customerId).List();
                    CustomerModel model = CustomersBL.TransferModel(list.ToList()).FirstOrDefault();
                    //ViewData["cusItem"] = model;
                    return View(model);
                }
            }
            else
            {
                return View(new CustomerModel());
            }
        }
    }
}
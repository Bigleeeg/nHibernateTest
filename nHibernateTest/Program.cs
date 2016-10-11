using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using nHibernateTest.Repository;
using NHibernate.Criterion;
using nHibernateTest.Entity;
using nHibernateTest.Infra;

namespace nHibernateTest
{
    class Program
    {
        static void Main(string[] args)
        {

            //数据库配置文件完全地址
            var dbConfigFullPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Northwind.cfg.xml");
            //Hibernate加载数据库配置文件
            var nHConfiguration = new NHibernate.Cfg.Configuration().Configure("Northwind.cfg.xml");
            //获得session工厂
            var sessionFactory = nHConfiguration.BuildSessionFactory();

            using (var session = sessionFactory.OpenSession())
            {

                var customer = new Customers()
                {
                    CustomerID = "luge",
                    CompanyName = "卤鸽",
                    Address = "博客园",
                    Phone = "123456"
                };
                //插入数据
                session.Save(customer);
                session.Flush();
                //get是直接执行sql语句得到实体对象
                var getCustomer = session.Get<Customers>("luge");


                getCustomer.CompanyName = "飞鸽";
                session.SaveOrUpdate(getCustomer);
                session.Flush();
                //load主要在是需要调用的时候才进行执行sql语句
                var loadCustomer = session.Load<Customers>("luge");
                session.Delete(loadCustomer);
                session.Flush();
            }

            //封装
            //var session = SessionFactory.GetCurrentSession("Northwind");

            //var uow = new NhUnitOfWork("Northwind");
            //var rep = new CustomersRepository(uow);

            // var tp = uow.Session.CreateCriteria(typeof(Customers)).CreateCriteria("Orders").List<Customers>();

            //for (int i = 0; i < 2; i++)
            //{
            //    Customers customer = new Customers()
            //   {
            //       CustomerID = "luge" + i.ToString(),
            //       CompanyName = "luge" + i.ToString()

            //   };
            //    rep.Add(customer);
            //}

            //uow.Commit();


            //视图数据的获取
            //var viewMapping = uow.Session.Get<CustomerAndSupplierView>("pigeon");

            // var tempCustomer = GetCustomer(uow);

            //更新
            //var getCustomer = rep.FindBy("ALFKI");
            //getCustomer.CompanyName = "pigeon";
            //rep.Save(getCustomer);
            //uow.Commit();


            //查询，并且按分页返回
            //var list=new List<ICriterion>();
            //list.Add(Restrictions.Eq("CompanyName", "Alfreds Futterkiste"));
            ////list.Add(Restrictions.Between("USRID",25,28));
            //int count;
            //var queryList = rep.FindBy(list, new Order("CustomerID", true), 1, 5, out count);




            Console.ReadLine();


        }
        /// <summary>
        /// 默认是开启延迟加载，如果关闭session之后，就会出现加载失败。可以通过NHibernateUtil.Initialize()进行立即加载
        /// </summary>
        /// <param name="uow"></param>
        /// <returns></returns>
        public static Customers GetCustomer(IUnitOfWork uow)
        {
            using (uow.Session)
            {
                var temp = uow.Session.Get<Customers>("ALFKI");
                NHibernate.NHibernateUtil.Initialize(temp.CustomerDemographics);
                return temp;
            }

        }
    }
}

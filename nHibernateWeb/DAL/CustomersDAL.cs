using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace nHibernateWeb.DAL
{
    public class CustomersDAL
    {

        public static ISessionFactory sessionFactory
        {
            get
            {
                //数据库配置文件完全地址
                var dbConfigFullPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Northwind.cfg.xml");
                //Hibernate加载数据库配置文件
                var nHConfiguration = new NHibernate.Cfg.Configuration().Configure(dbConfigFullPath);
                //获得session工厂
                var sessionFactory = nHConfiguration.BuildSessionFactory();

                return sessionFactory; 
            }
        }
    }
}
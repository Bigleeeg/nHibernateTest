//=====================================================
//Copyright (C) 2015-2015 
//All rights reserved
//CLR版本:        4.0.30319.34011
//文件名:           SessionFactory
//创建时间:     2015/5/28 10:01:51
//当前登录用户名:   卤鸽
//创建年份:         2015
//描述：
//======================================================
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Cfg;

namespace nHibernateTest.Infra
{
    public class SessionFactory
    {
        

        private static Dictionary<string, ISessionFactory> _sessionFactoryDic = new Dictionary<string, ISessionFactory>();

        /// <summary>
        /// 通过数据库名称获取该数据库的配置文件的地址(未写完）
        /// </summary>
        /// <param name="dbName"></param>
        /// <returns></returns>
        private static string GetConfigPathByDbName(string dbName)
        {

            var path = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format("{0}.cfg.xml", dbName));


            return path;
        }

        private static void Init(string dbName)
        {
            
            Configuration config = new Configuration();

            //log4net.Config.XmlConfigurator.Configure();

            //配置文件地址
            string dbConfigPath = GetConfigPathByDbName(dbName);

            config.Configure(dbConfigPath);

            ISessionFactory sessionFactory=config.BuildSessionFactory();

            _sessionFactoryDic.Add(dbName, sessionFactory);

        }

        private static ISessionFactory GetSessionFactory(string dbName)
        {

            if (!_sessionFactoryDic.Keys.Contains(dbName))
            {
                Init(dbName);
            }
            return _sessionFactoryDic[dbName];
        }

        private static ISession GetNewSession(string dbName)
        {
            return GetSessionFactory(dbName).OpenSession();
        }

        public static ISession GetCurrentSession(string dbName)
        {
            ISessionStorageContainer sessionStorageContainer = SessionStorageFactory.GetStorageContainer();

            ISession currentSession = sessionStorageContainer.GetCurrentSession(dbName);

            if (currentSession == null)
            {
                currentSession = GetNewSession(dbName);
                sessionStorageContainer.Store(dbName, currentSession);
            }

            return currentSession;
        }

    }
}

//=====================================================
//Copyright (C) 2015-2015 
//All rights reserved
//CLR版本:        4.0.30319.34011
//文件名:           NhUnitOfWork
//创建时间:     2015/5/28 14:44:11
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

namespace nHibernateTest.Infra
{
    public class NhUnitOfWork : IUnitOfWork
    {
        private string _dbName = string.Empty;

        private ISession _session;
        //public ISession Session { get; }

        public ISession Session
        {
            get { return _session; }
        }
        public NhUnitOfWork(string dbName)
        {
            _dbName = dbName;
            _session = SessionFactory.GetCurrentSession(_dbName);
        }

      
        public void RegisterAmended(IAggregateRoot entity)
        {
            Session.SaveOrUpdate(entity);

        }

        public void RegisterNew(IAggregateRoot entity)
        {
            Session.Save(entity);
        }

        public void RegisterRemoved(IAggregateRoot entity)
        {
            Session.Delete(entity);
        }

        public void Commit()
        {
            using (ITransaction transaction = Session.BeginTransaction())
            {
                try
                { 
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }



        
    }
}

//=====================================================
//Copyright (C) 2015-2015 
//All rights reserved
//CLR版本:        4.0.30319.34011
//文件名:           IUnitOfWork
//创建时间:     2015/5/28 14:03:31
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
    public interface IUnitOfWork
    {
        ISession Session { get; }
        void RegisterAmended(IAggregateRoot entity);
        void RegisterNew(IAggregateRoot entity);
        void RegisterRemoved(IAggregateRoot entity);
        
        void Commit();
    }
}

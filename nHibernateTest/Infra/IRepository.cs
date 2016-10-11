//=====================================================
//Copyright (C) 2015-2015 
//All rights reserved
//CLR版本:        4.0.30319.34011
//文件名:           IRepository
//创建时间:     2015/5/28 15:06:00
//当前登录用户名:   卤鸽
//创建年份:         2015
//描述：
//======================================================
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Criterion;

namespace nHibernateTest.Infra
{
    public interface IRepository<T, EntityKey> where T : IAggregateRoot
    {
         void Add(T entity);

         void Remove(T entity);

         void Save(T entity);

         T FindBy(EntityKey Id);

         IEnumerable<T> FindAll();

         IEnumerable<T> FindAll(int index, int pageSize, out int count);

         IEnumerable<T> FindBy(IList<ICriterion> queryList, Order order);

         IEnumerable<T> FindBy(IList<ICriterion> queryList,Order order, int index,int pageSize,out  int count);
    }
}

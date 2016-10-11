//=====================================================
//Copyright (C) 2015-2015 
//All rights reserved
//CLR版本:        4.0.30319.34011
//文件名:           Repository
//创建时间:     2015/5/28 17:07:57
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
using NHibernate.Criterion;

namespace nHibernateTest.Infra
{
    public abstract class Repository<T, EntityKey> : IRepository<T, EntityKey>
        where T : IAggregateRoot
    {
        private IUnitOfWork _uow;


        public Repository(IUnitOfWork uow)
        {
            _uow = uow;

        }

        public void Add(T entity)
        {
            _uow.RegisterNew(entity);
            //throw new NotImplementedException();
        }

        public void Remove(T entity)
        {
            _uow.RegisterRemoved(entity);
            //throw new NotImplementedException();
        }

        public void Save(T entity)
        {
            _uow.RegisterAmended(entity);
        }

        public T FindBy(EntityKey Id)
        {
            return _uow.Session.Get<T>(Id);
        }

        public IEnumerable<T> FindAll()
        {
            return (List<T>)_uow.Session.CreateCriteria(typeof(T)).List();
        }

        public IEnumerable<T> FindAll(int index, int pageSize, out int count)
        {
            ICriteria CriteriaQuery = _uow.Session.CreateCriteria(typeof(T));

            index=(index>=1?index:1);


            var countCirteria = CriteriaQuery.Clone() as ICriteria;

            var futureCount = countCirteria.SetProjection(Projections.RowCount()).FutureValue<Int32>();

            count = futureCount.Value;

            var queryList = CriteriaQuery.SetFirstResult((index-1)*pageSize).SetMaxResults(pageSize).List();



            return (List<T>)queryList;
        }

        public IEnumerable<T> FindBy(IList<ICriterion> queryList, Order order)
        {
            //Restrictions.Eq("Category.Id", 2) 进行添加查询数据
            ICriteria CriteriaQuery = _uow.Session.CreateCriteria(typeof(T));

            foreach (var queryItem in queryList)
            {
                CriteriaQuery.Add(queryItem);
            }

            return CriteriaQuery.AddOrder(order).List<T>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="queryList"></param>
        /// <param name="order"></param>
        /// <param name="index"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public IEnumerable<T> FindBy(IList<ICriterion> queryList, Order order, int index, int pageSize, out int count)
        {

            ICriteria CriteriaQuery = _uow.Session.CreateCriteria(typeof(T));

            foreach (var queryItem in queryList)
            {
                CriteriaQuery.Add(queryItem);
            }

            var listByQuery = CriteriaQuery;


            var countCrieriaQuery = CriteriaQuery.Clone() as ICriteria;

            //            // Get the total row count in the database.
            //var rowCount = this.Session.CreateCriteria(typeof(EventLogEntry))
            //    .Add(Expression.Between("Timestamp", startDate, endDate))
            //    .SetProjection(Projections.RowCount()).FutureValue<Int32>();

            //// Get the actual log entries, respecting the paging.
            //var results = this.Session.CreateCriteria(typeof(EventLogEntry))
            //    .Add(Expression.Between("Timestamp", startDate, endDate))
            //    .SetFirstResult(pageIndex * pageSize)
            //    .SetMaxResults(pageSize)
            //    .Future<EventLogEntry>();



            var rowCount = countCrieriaQuery.SetProjection(Projections.RowCount()).FutureValue<Int32>();

            count = rowCount.Value;

            index = index >= 1 ? index : 1;

            return listByQuery.AddOrder(order).SetFirstResult((index - 1) * pageSize).SetMaxResults(pageSize).List<T>();



        }
    }
}

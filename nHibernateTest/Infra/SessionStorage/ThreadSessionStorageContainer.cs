//=====================================================
//Copyright (C) 2015-2015 
//All rights reserved
//CLR版本:        4.0.30319.34011
//文件名:           ThreadSessionStorage
//创建时间:     2015/5/28 10:01:07
//当前登录用户名:   卤鸽
//创建年份:         2015
//描述：
//======================================================
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NHibernate;

namespace nHibernateTest.Infra
{
    public class ThreadSessionStorageContainer : ISessionStorageContainer
    {
        private static readonly Hashtable _nhSessions = new Hashtable();

        private string _sessionPrefixKey = "NHSession";

        private string FormatSessionKey(string key)
        {
            var fullKey = string.Format("{0}_{1}_{2}", _sessionPrefixKey,GetThreadName(), key);
            return fullKey;
        }


        private static string GetThreadName()
        {
            return Thread.CurrentThread.Name;
        }

        #region ISessionStorageContainer

        /// <summary>
        ///
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public NHibernate.ISession GetCurrentSession(string key)
        {
            var sessionKey = this.FormatSessionKey(key);
            ISession nhSession = null;

            if (_nhSessions.Contains(sessionKey))
                nhSession = (_nhSessions[sessionKey] as ISession);

            return nhSession;
        }

        public void Store(string key, NHibernate.ISession session)
        {
            var sessionKey = this.FormatSessionKey(key);
            if (_nhSessions.Contains(sessionKey ))
                _nhSessions[sessionKey] = session;
            else
                _nhSessions.Add(sessionKey, session);
        }


        #endregion
       
    }
}

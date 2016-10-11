//=====================================================
//Copyright (C) 2015-2015 
//All rights reserved
//CLR版本:        4.0.30319.34011
//文件名:           HttpSessionStorage
//创建时间:     2015/5/28 10:00:09
//当前登录用户名:   卤鸽
//创建年份:         2015
//描述：
//======================================================
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using NHibernate;

namespace nHibernateTest.Infra
{
    /// <summary>
    /// 针对web应用程序
    /// </summary>
    public class HttpSessionStorageContainer : ISessionStorageContainer
    {
        private string _sessionPrefixKey = "NHSession";

        private string FormatSessionKey(string key)
        {
            var fullKey = string.Format("{0}_{1}", _sessionPrefixKey, key);
            return fullKey;
        }
        /// <summary>
        ///
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public ISession GetCurrentSession(string key)
        {

            var sessionKey = FormatSessionKey(key);
            ISession nhSession = null; ;

            //if (HttpContext.Current.Items.Contains(key))
            //{
            //    nhSession = (HttpContext.Current.Items[sessionKey] as ISession);
            //}
            return nhSession;
        }

        public void Store(string key, ISession session)
        {
            var sessionKey = FormatSessionKey(key);
            //if (HttpContext.Current.Items.Contains(sessionKey))
            //    HttpContext.Current.Items[sessionKey] = session;
            //else
            //    HttpContext.Current.Items.Add(sessionKey, session);
        }


    }
}

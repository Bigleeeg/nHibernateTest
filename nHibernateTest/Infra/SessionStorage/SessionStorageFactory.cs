//=====================================================
//Copyright (C) 2015-2015 
//All rights reserved
//CLR版本:        4.0.30319.34011
//文件名:           SessionStorageFactory
//创建时间:     2015/5/28 10:01:31
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

namespace nHibernateTest.Infra
{
    public static class SessionStorageFactory
    {
        public static ISessionStorageContainer _nhSessionStorageContainer;

        public static ISessionStorageContainer GetStorageContainer()
        {
            if (_nhSessionStorageContainer == null)
            {
                //if (HttpContext.Current == null)
                //    _nhSessionStorageContainer = new ThreadSessionStorageContainer();
                //else
                    _nhSessionStorageContainer = new HttpSessionStorageContainer();
            }

            return _nhSessionStorageContainer;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
namespace nHibernateTest.Infra
{
    /// <summary>
    /// 
    /// </summary>
    public interface ISessionStorageContainer
    {

        ISession GetCurrentSession(string key);
        void Store(string key ,ISession session);

    }
}

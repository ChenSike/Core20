using System;
using System.Collections.Generic;
using System.Text;
using Core20Go.Entity.IEntity;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace Core20Go.Context.ContextInterface
{
    public interface IDataBaseContext
    {
        IConfApp confApp { set; get; }

        int ExecuteSqlNonReturn(string connectionName,string sql, List<IEntity> entities);

        List<IEntity> ExecuteSqlReturns(string connectionName, string sql, IEntity entity);

        IEntity ExecuteSqlReturn(string connectionName, string sql, IEntity entity);
        
    }
}

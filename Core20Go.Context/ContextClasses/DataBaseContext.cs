using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using Dapper;
using Core20Go.Context.ContextInterface;
using Core20Go.Entity.IEntity;

namespace Core20Go.Context.ContextClasses
{
    public class DataBaseContext : IDataBaseContext
    {
        public IConfApp confApp
        {
            set;
            get;
        }
        public DataBaseContext(IConfApp confApp)
        {
            this.confApp = confApp;
        }

        public int ExecuteSqlNonReturn(string connectionName, string sql, List<IEntity> entities)
        {
            using (IDbConnection dbConnection = new MySqlConnection(confApp.GetDBConnectionString(connectionName)))
            {
                int result = 0;
                try
                {
                    dbConnection.Open();
                    if (entities != null && entities.Count > 0)
                    {
                        result = dbConnection.Execute(sql, entities);
                    }
                    else
                    {
                        result = dbConnection.Execute(sql);
                    }
                }
                catch
                {
                    throw new Exception();
                }
                finally
                {
                    dbConnection.Close();                    
                }
                return result;

            }
        }

        public List<IEntity> ExecuteSqlReturns(string connectionName, string sql,IEntity entity)
        {
            using (IDbConnection dbConnection = new MySqlConnection(confApp.GetDBConnectionString(connectionName)))
            {
                List<IEntity> entities = new List<IEntity>();
                try
                {
                    dbConnection.Open();
                    if (entity != null)
                    {
                        entities = dbConnection.Query<IEntity>(sql, entity).AsList();
                    }
                    else
                    {
                        entities = dbConnection.Query<IEntity>(sql).AsList();
                    }
                }
                catch
                {
                    throw new Exception();
                }
                finally
                {
                    dbConnection.Close();
                }
                return entities;

            }
        }

        public IEntity ExecuteSqlReturn(string connectionName, string sql, IEntity entity)
        {
            using (IDbConnection dbConnection = new MySqlConnection(confApp.GetDBConnectionString(connectionName)))
            {
                IEntity entityObj;
                try
                {
                    dbConnection.Open();
                    if (entity != null)
                    {
                        entityObj = dbConnection.QueryFirstOrDefault(sql, entity);
                    }
                    else
                    {
                        entityObj = dbConnection.QueryFirstOrDefault(sql);
                    }
                }
                catch
                {
                    throw new Exception();
                }
                finally
                {
                    dbConnection.Close();
                }
                return entityObj;

            }
        }
    }
}

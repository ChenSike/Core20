using Core20Go.Context.ContextInterface;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Core20Go.Repository
{
    public class Repository_UserBasic : RepositoryInterface.IRepositoryUserBasic
    {

        public IDataBaseContext DataBaseContext
        {
            set;
            get;
        }
        
        public Dictionary<string, string> tableMap
        {
            set;
            get;
        }

        public Repository_UserBasic(IDataBaseContext dataBaseContext)
        {
            this.DataBaseContext = dataBaseContext;
            tableMap = new Dictionary<string, string>();
            tableMap.Add("user_basic", "user_basic");
        }

        public int NewUser(Entity.IEntity.IEntity entity)
        {
            string sql = "insert into " + tableMap["user_basic"] + "(uid,uname,pwd,status) values(@uid,@uname,@pwd,@status)";
            List<Entity.IEntity.IEntity> entities = new List<Entity.IEntity.IEntity>();
            entities.Add(entity);
            return this.DataBaseContext.ExecuteSqlNonReturn(entity.ConnectionName, sql, entities);
        }

        public Entity.IEntity.IEntity SelectUser(Entity.IEntity.IEntity entity)
        {
            string sql = "select * from " + tableMap["user_basic"] + " where uid=@uid or name=@name";
            return DataBaseContext.ExecuteSqlReturn(entity.ConnectionName, sql, entity);
        }
        
        public int UpdatePassword(Entity.IEntity.IEntity entity)
        {
            string sql = "update " + tableMap["user_basic"] + " set pwd=@pwd where uid=@uid";
            List<Entity.IEntity.IEntity> entities = new List<Entity.IEntity.IEntity>();
            entities.Add(entity);
            return this.DataBaseContext.ExecuteSqlNonReturn(entity.ConnectionName, sql, entities);
        }

        public int UpdateStatus(Entity.IEntity.IEntity entity)
        {
            string sql = "update " + tableMap["user_basic"] + " set status=@status where uid=@uid";
            List<Entity.IEntity.IEntity> entities = new List<Entity.IEntity.IEntity>();
            entities.Add(entity);
            return this.DataBaseContext.ExecuteSqlNonReturn(entity.ConnectionName, sql, entities);
        }

    }
}
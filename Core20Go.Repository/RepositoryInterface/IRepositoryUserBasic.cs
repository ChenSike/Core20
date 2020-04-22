using System;
using System.Collections.Generic;
using System.Text;

namespace Core20Go.Repository.RepositoryInterface
{
    public interface IRepositoryUserBasic:IDataRepository
    {

        int NewUser(Entity.IEntity.IEntity entity);

        Entity.IEntity.IEntity SelectUser(Entity.IEntity.IEntity entity);

        int UpdatePassword(Entity.IEntity.IEntity entity);


        int UpdateStatus(Entity.IEntity.IEntity entity);
        
    }
}

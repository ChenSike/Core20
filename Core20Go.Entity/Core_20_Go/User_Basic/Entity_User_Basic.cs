using System;
using System.Collections.Generic;
using System.Text;

namespace Core20Go.Entity.Core_20_Go.User_Basic
{
    public class Entity_User_Basic : IEntity.IEntity
    {
        public string uid
        {
            set;
            get;
        }

        public string uname
        {
            set;
            get;
        }

        public string pwd
        {
            set;
            get;
        }

        public string status
        {
            set;
            get;
        }

        public string ConnectionName 
        {
            get;
            set;
        }
    }
}

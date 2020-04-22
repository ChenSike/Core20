using System;
using System.Collections.Generic;
using System.Text;

namespace Core20Go.Context.BasicStructs
{
    public class Struct_DBConnectionConfig
    {
        public BasicEnums.Enum_DBType sourceType
        {
            set;
            get;
        }
        public string server
        {
            set;
            get;
        }

        public string database
        {
            set;
            get;
        }

        public string uid
        {
            set;
            get;
        }

        public string pwd
        {
            set;
            get;
        }

        public bool AESMode
        {
            set;
            get;
        }

    }
}

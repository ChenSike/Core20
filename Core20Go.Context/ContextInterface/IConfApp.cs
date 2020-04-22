using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace Core20Go.Context.ContextInterface
{
    public interface IConfApp
    {


        IConfiguration ConfigurationObject
        {
            set;
            get;
        }

        void LoadConfigs();

        bool LoadDBConstring(string ConnectionName);

        String SetDBConnectionString(BasicStructs.Struct_DBConnectionConfig struct_DBConnectionConfig);

        String GetDBConnectionString(string ConnectionName);


    }
}

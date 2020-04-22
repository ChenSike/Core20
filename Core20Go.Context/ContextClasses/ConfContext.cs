using System;
using System.Collections.Generic;
using System.Text;
using Core20Go.Context.BasicEnums;
using Core20Go.Context.ContextInterface;
using Microsoft.Extensions.Configuration;

namespace Core20Go.Context.ContextClasses
{
    public class ConfContext : IConfApp
    {
        public Dictionary<string, BasicStructs.Struct_DBConnectionConfig> CollectionsDBConnections
        {
            get;
            set;
        }

        public static string TemplateConnectionString_MySql = "server={server};uid={uid};password={password};database={database};";

        public IConfiguration ConfigurationObject
        {
            set;
            get;
        }

        public ConfContext(IConfiguration configuration)
        {
            ConfigurationObject = configuration;
            CollectionsDBConnections = new Dictionary<string, BasicStructs.Struct_DBConnectionConfig>();
        }
       
        public void LoadConfigs()
        {
            throw new NotImplementedException();
        }

        public bool LoadDBConstring(string connectionName)
        {
            try
            {
                string appStrHeader = "DBConnection:" + connectionName;
                var AESHelperObj = new Helper.Helper_AES();
                var isAES = ConfigurationObject[appStrHeader + ":AESMode"] == "1" ? true : false;
                var type = ConfigurationObject[appStrHeader + ": Type"];
                var server = isAES ? AESHelperObj.AesDecrypt(ConfigurationObject[appStrHeader + ":Server"]) : ConfigurationObject[appStrHeader + ":Server"];
                var uid = isAES ? AESHelperObj.AesDecrypt(ConfigurationObject[appStrHeader + ":Uid"]) : ConfigurationObject[appStrHeader + ":Uid"];
                var pwd = isAES ? AESHelperObj.AesDecrypt(ConfigurationObject[appStrHeader + ":Pwd"]) : ConfigurationObject[appStrHeader + ":Pwd"];
                var database = isAES ? AESHelperObj.AesDecrypt(ConfigurationObject[appStrHeader + ":Database"]) : ConfigurationObject[appStrHeader + ":Database"];
                BasicStructs.Struct_DBConnectionConfig struct_DBConnectionConfig = new BasicStructs.Struct_DBConnectionConfig();
                struct_DBConnectionConfig.AESMode = isAES;
                struct_DBConnectionConfig.database = database;
                struct_DBConnectionConfig.uid = uid;
                struct_DBConnectionConfig.pwd = pwd;
                struct_DBConnectionConfig.server = server;
                struct_DBConnectionConfig.sourceType = (Enum_DBType)Enum.Parse(typeof(Enum_DBType), type);
                CollectionsDBConnections.Add(connectionName, struct_DBConnectionConfig);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public string GetDBConnectionString(string ConnectionName)
        {
            if(CollectionsDBConnections.ContainsKey(ConnectionName))
            {
                return SetDBConnectionString(CollectionsDBConnections[ConnectionName]);
            }
            else
            {
                if (LoadDBConstring(ConnectionName))
                    return SetDBConnectionString(CollectionsDBConnections[ConnectionName]);
                else
                    return string.Empty;
            }
        }

        public string SetDBConnectionString(BasicStructs.Struct_DBConnectionConfig struct_DBConnectionConfig)
        {
            switch (struct_DBConnectionConfig.sourceType)
            {
                case Enum_DBType.mysql:
                    TemplateConnectionString_MySql = TemplateConnectionString_MySql.Replace("{server}", struct_DBConnectionConfig.server);
                    TemplateConnectionString_MySql = TemplateConnectionString_MySql.Replace("{uid}", struct_DBConnectionConfig.uid);
                    TemplateConnectionString_MySql = TemplateConnectionString_MySql.Replace("{password}", struct_DBConnectionConfig.pwd);
                    TemplateConnectionString_MySql = TemplateConnectionString_MySql.Replace("{database}", struct_DBConnectionConfig.database);
                    return TemplateConnectionString_MySql;
            }
            return string.Empty;
        }
    }
}

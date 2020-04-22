using System;
using System.Collections.Generic;
using System.Text;
using Core20Go.Context;

namespace Core20Go.Repository.RepositoryInterface
{
    public interface IDataRepository
    {
        Dictionary<string,string> tableMap
        {
            set;
            get;
        }

        Context.ContextInterface.IDataBaseContext DataBaseContext
        {
            set;
            get;
        }
    }
}

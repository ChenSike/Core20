using System;
using System.Collections.Generic;
using System.Text;

namespace Core20Go.SupTool
{

    public class MessageNode
    { 
        public string Action
        {
            set;
            get;
        }

        public bool Result
        {
            set;
            get;            
        }

        

    }


    public class ConsoleController
    {
        public Queue<MessageNode> messageNodes = new Queue<MessageNode>();

        

    }
}

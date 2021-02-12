using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace 责任链模式
{
    //链条
    class Chain
    {
        private int index = 0;

        private List<AbstractHandler> handlers=new List<AbstractHandler>();

        public Chain Add(AbstractHandler handler)
        {
            handlers.Add(handler);
            return this;
        }

        public  bool HandlerLeaveRequest(LeaveContext leaveContext)
        {
            foreach (var handler in handlers)
            {
                if (!handler.HandlerLeaveRequest(leaveContext))
                {
                    return false;
                }
            }
            return true;
        }

        public bool Filter(LeaveContext leaveContext)
        {
            if (index == handlers.Count) return false;
            var handler=handlers[index];
            index++;
            return handler.Filter(leaveContext, this);
        }
    }
}

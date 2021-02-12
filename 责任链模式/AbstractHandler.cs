using System;
using System.Collections.Generic;
using System.Text;

namespace 责任链模式
{
    abstract class AbstractHandler
    {
        //请假时间
        public int Days { get; set; } 

        public string Name { get; set; }
        //领导响应
        public  string LeaderResponse { get; set; }

        private AbstractHandler NextHandler { get; set; }

        public void SetHandler (AbstractHandler handler)
        {
            NextHandler = handler;
        }

        protected void NextLeaveRequest(LeaveContext leaveContext)
        {
            NextHandler.HandlerLeaveRequest(leaveContext);
        }

        public abstract bool HandlerLeaveRequest(LeaveContext leaveContext);

        public abstract bool Filter(LeaveContext leaveContext, Chain chain);

    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace 责任链模式
{
    class 总裁:AbstractHandler
    {
        

        public override bool HandlerLeaveRequest(LeaveContext leaveContext)
        {
            if (leaveContext.Day > 15 && leaveContext.Day <= this.Days)
            {
                Console.Write($"职位：{Name}: 审批通过.");
                return false;
            }

            return true;
        }

        public override bool Filter(LeaveContext leaveContext, Chain chain)
        {
            leaveContext.Description = leaveContext.Description.Replace("ABC", "3.CEO");
            Console.Write($"{leaveContext.Description}");
            Console.WriteLine("");
            chain.Filter(leaveContext);
            leaveContext.AuditRemark = $"{Name}: 修改-->";
            Console.WriteLine($"{leaveContext.AuditRemark}");
            return true;
        }
    }
}

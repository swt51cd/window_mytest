using System;
using System.Runtime.CompilerServices;

namespace 责任链模式
{
    class 主管 : AbstractHandler
    {

        public override bool HandlerLeaveRequest(LeaveContext leaveContext)
        {
            if (leaveContext.Day > 0 && leaveContext.Day <= this.Days)
            {
                Console.Write($"职位：{Name}:审批通过.");
                return false;
            }
            return true;
            //else 第一种
            //{
            //    NextLeaveRequest(leaveContext);
            //    return;
            //}
        }

        public override bool Filter(LeaveContext leaveContext, Chain chain)
        {
            leaveContext.Description = leaveContext.Description.Replace("shuoming", "1-主管");
            //Console.Write($"***{leaveContext.Description}--->>");
            chain.Filter(leaveContext);
            leaveContext.AuditRemark = $"{Name}: 修改-->";
            Console.WriteLine($"{leaveContext.AuditRemark}");
            return true;
        }
    }
}
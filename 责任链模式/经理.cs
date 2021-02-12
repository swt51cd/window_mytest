using System;
using System.Collections.Generic;
using System.Text;

namespace 责任链模式
{
    class 经理:AbstractHandler
    {
        public override bool HandlerLeaveRequest(LeaveContext leaveContext)
        {
            if (leaveContext.Day > 7 && leaveContext.Day <= this.Days)
            {
                Console.Write($"职位：{Name} : 审批通过.");
                return false;
            }
            return true;
            //else 第一种
            //{
            //   NextLeaveRequest(leaveContext);
            //    return;
            //}
        }

        public override bool Filter(LeaveContext leaveContext,Chain chain)
        {
            leaveContext.Description = leaveContext.Description.Replace("123", "2.经理");
            //Console.Write($"***{leaveContext.Description}");
            chain.Filter(leaveContext);
            leaveContext.AuditRemark = $"{Name}: 修改-->";
            Console.WriteLine($"{leaveContext.AuditRemark}");
            return true;
        }
    }
}

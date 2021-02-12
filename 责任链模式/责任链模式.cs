namespace 责任链模式
{
    class 责任链模式
    {

    }

    public class LeaveContext
    {
        public string Name { get; set; }
        public int Id { get; set; }
        //时长
        public int Day { get; set; }
        //说明
        public string Description { get; set; }
        //是否审批
        public bool AuditResult { get; set; }
        public string AuditRemark { get; set; }
    }


}

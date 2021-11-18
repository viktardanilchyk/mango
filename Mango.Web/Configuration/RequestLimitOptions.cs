namespace Mango.Configuration
{
    public class RequestLimitOptions
    {
        public int ApprovedRequestLimitInMilliseconds { get; set; }
        
        public int ApprovedRequestLimitCount { get; set; }
        
        public int DeclinedRequestLimitInMilliseconds { get; set; }
        
        public int DeclinedRequestLimitCount { get; set; }
    }
}
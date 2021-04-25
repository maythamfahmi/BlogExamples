using System.Net;

namespace WcfService.Model
{
    public class Result
    {
        public Applicant Applicant { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public string Message { get; set; }
    }
}

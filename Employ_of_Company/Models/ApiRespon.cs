using System.Net;

namespace Employ_of_Company.Models
{
    public class ApiRespon
    {
        public ApiRespon()
        {
            Errormessages = new List<string>();
        }
        public bool issucces { get; set; }
        public object result { get; set; }

        public HttpStatusCode statuscode { get; set; }

        public List<string> Errormessages { get; set; }
    }
}

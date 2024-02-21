namespace Employ_of_Company.Models
{
    public class ApiRespon
    {
        public ApiRespon()
        {
            List<string> Errormessages = new();
        }
        public object result { get; set; }

        public bool issucces { get; set; }

        public string statuscode { get; set; }

        public List<string> Errormessages { get; set; }
    }
}

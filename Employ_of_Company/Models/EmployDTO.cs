namespace Employ_of_Company.Models
{
    public class EmployDTO
    {
        public string Name { get; set; }

        public string Position { get; set; }

        public string Phone { get; set; } = "";

        public DateTime? CreatedDate { get; set; } = DateTime.Now;

    }
}

namespace Employ_of_Company.Models
{
    public class EmployInfo
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Position { get; set; }

        public string Phone { get; set; } 

        public DateTime? CreatedDate { get; set; } = DateTime.Now;

        public DateTime? ModifiedDate { get; } = DateTime.Now;




    }
}

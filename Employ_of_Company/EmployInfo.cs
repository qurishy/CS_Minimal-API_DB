namespace Employ_of_Company
{
    public class EmployInfo
    {
        public int Id { get; set; } 

        public string Name { get; set; }

        public string Position { get; set; }

        public string Phone { get; set; }

        public DateTime? CreatedDate { get; set; } = default(DateTime?);

        public DateTime? ModifiedDate { get;} = default(DateTime?);




    }
}

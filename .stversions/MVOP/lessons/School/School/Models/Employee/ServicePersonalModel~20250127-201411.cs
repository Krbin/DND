using SQLite;

namespace School.Models.Employee
{
    public class ServicePersonalModel
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}

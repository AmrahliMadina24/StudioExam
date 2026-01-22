using StudioExam.Models.Common;

namespace StudioExam.Models
{
    public class Position: BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public ICollection<Employee> Employees { get; set; } = [];
    }
}

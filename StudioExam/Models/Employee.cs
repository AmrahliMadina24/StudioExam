using StudioExam.Models.Common;

namespace StudioExam.Models
{
    public class Employee : BaseEntity
    {
        public string FullName { get; set; } = string.Empty;
        public string ImagePath { get; set; } = string.Empty;
        public int PositionId { get; set; }
        public Position Position { get; set; } = null!;
    }
}

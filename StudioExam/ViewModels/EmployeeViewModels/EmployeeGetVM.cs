namespace StudioExam.ViewModels.EmployeeViewModels
{
    public class EmployeeGetVM
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string ImagePath { get; set; } = string.Empty;

        public string PositionName { get; set; } = null!;
    }
}
